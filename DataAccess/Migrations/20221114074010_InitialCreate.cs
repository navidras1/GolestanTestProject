using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RetailStores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ipaddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsTell = table.Column<bool>(type: "bit", nullable: true),
                    ParenetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetailStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetailStores_RetailStores_ParenetId",
                        column: x => x.ParenetId,
                        principalTable: "RetailStores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetailStoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkStations_RetailStores_RetailStoreId",
                        column: x => x.RetailStoreId,
                        principalTable: "RetailStores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RetailStores_ParenetId",
                table: "RetailStores",
                column: "ParenetId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkStations_RetailStoreId",
                table: "WorkStations",
                column: "RetailStoreId");

            string PROC_AddRetailStore = @"
                    CREATE PROCEDURE PROC_AddRetailStore 
            @Name nvarchar(500),
            @Address nvarchar(500),
            @IPAddress varchar(15),
            @OpeningDate datetime,
            @IsActive bit,
            @IsTell bit

            as

             declare @newId nvarchar(50)
             declare @message nvarchar(50) = N'عملیات با موفقیت انجام شد'
             declare @IsSuccessful bit = 1
             begin try

             IF EXISTS(SELECT * FROM [RetailStores] WHERE [Name]=@Name)
             begin
            	THROW 51000, N'نام شعبه از قبل موجود است', 1;  
             end


             set @newId = NEWID();
            INSERT INTO [dbo].[RetailStores]
                       ([Id]
                       ,[Name]
                       ,[Address]
                       ,[IPAddress]
                       ,[OpeningDate]
                       ,[IsActive]
                       ,[IsTell]
                       )
                 VALUES
                       (@newId
                       ,@Name
                       ,@Address
                       ,@IPAddress
                       ,@OpeningDate
                       ,@IsActive
                       ,@IsTell
                       )

            end try
            begin catch

            	set @message= ERROR_MESSAGE()
                set @newId=''
                set @IsSuccessful = 0
            end catch
             select  @IsSuccessful IsSuccessful , @newId TheId, @message Message

            GO
            ";
            migrationBuilder.Sql(PROC_AddRetailStore);


            string PROC_UpdateRetailStore = @"
       Create PROCEDURE PROC_UpdateRetailStore
	   @Id uniqueidentifier
      ,@Name  nvarchar(max)
      ,@Address  nvarchar(max)
      ,@Ipaddress  nvarchar(max)
      ,@OpeningDate datetime2(7)
      ,@IsActive bit
	  ,@IsTell bit
      
as
	
	
	declare @message nvarchar(50) = N'عملیات با موفقیت انجام شد'
    declare @IsSuccessful bit = 1

	

	begin try

	if (not Exists(select * from [RetailStores] where Id=@Id))
	begin
		THROW 51000, N'شناسه مورد نظر یافت نشد', 1;  
	end

	IF ( EXISTS(select * from [RetailStores] where Id<>@Id and Name=@Name))
	begin
		THROW 51001, N'نام انتخاب شده تکراری  است.', 1;  
	end

	UPDATE [dbo].[RetailStores]
	   SET [Name] = @Name
		  ,[Address] = @Address
		  ,[Ipaddress] = @Ipaddress
		  ,[OpeningDate] = @OpeningDate
		  ,[IsActive] = @IsActive
		  ,[IsTell] = @IsTell
      
	 WHERE Id=@Id

	 end try
	 begin catch
		set @message= ERROR_MESSAGE()
        set @IsSuccessful = 0
	 end catch
	 select  @IsSuccessful IsSuccessful, @message Message
            ";
            migrationBuilder.Sql(PROC_UpdateRetailStore);

            string PROC_DeleteRetailStore = @"
            Create PROCEDURE PROC_DeleteRetailStore
@Id uniqueidentifier

as

	declare @IsSuccessful bit = 1 
	declare @Message nvarchar(50) = N'عملیات با موفقیت انجام شد.' 

	begin try

	if (not Exists(select * from [RetailStores] where Id=@Id))
	begin
		THROW 51000, N'شناسه مورد نظر یافت نشد', 1;  
	end

	IF (EXISTS(SELECT * FROM WorkStations WHERE RetailStoreId=@Id))
	BEGIN
		THROW 51001, N'شعبه مورد نظر دارای صندوق میباشد ابتدا صندوق های مرتبط را حذف کنید.', 1;  
	END

	DELETE FROM [dbo].[RetailStores]
		  WHERE Id=@Id

	end try
	begin catch
		set @message= ERROR_MESSAGE()
        set @IsSuccessful = 0
	end catch
	select  @IsSuccessful IsSuccessful, @message Message
";

            migrationBuilder.Sql(PROC_DeleteRetailStore);

            string PROC_AddWorkStations = @"
            CREATE PROCEDURE PROC_AddWorkStations

@RetailStoreId  uniqueidentifier
,@Name nvarchar(max)
,@Location nvarchar(max)
,@IsActive bit

as
			declare @newId int=0
             declare @message nvarchar(50) = N'عملیات با موفقیت انجام شد'
             declare @IsSuccessful bit = 1

			 begin try

			 IF (not Exists(select * from RetailStores where Id=@RetailStoreId ))
			 begin
				THROW 51000, N'شناسه شعبه صحیح نیست', 1;  
			 end

			 If (exists(select * from WorkStations where RetailStoreId=@RetailStoreId and Name=@Name))
			 begin
				THROW 51001, N'نام صندوق در این شعبه تکراری است.', 1;  
			 end


				INSERT INTO [dbo].[WorkStations]
						   ([RetailStoreId]
						   ,[Name]
						   ,[Location]
						   ,[IsActive])
					 VALUES
						   (@RetailStoreId
						   ,@Name
						   ,@Location
						   ,@IsActive)

				set @newId = @@IDENTITY
		   end try
		   begin catch
				set @message= ERROR_MESSAGE()
                set @newId=''
                set @IsSuccessful = 0
		   end catch
		   select  @IsSuccessful IsSuccessful , @newId TheId, @message Message
";

            migrationBuilder.Sql(PROC_AddWorkStations);

            var PROC_UpdateWorkStations = @"

            Create PROCEDURE [dbo].[PROC_UpdateWorkStations]
      @Id int 
	  ,@RetailStoreId uniqueidentifier
      ,@Name nvarchar(max)
      ,@Location nvarchar(max)
      ,@IsActive  bit

as

	declare @message nvarchar(50) = N'عملیات با موفقیت انجام شد'
    declare @IsSuccessful bit = 1

	begin try

		if (exists(select * from [WorkStations] where Id=@Id))
		begin
			THROW 51000, N'شناسه مورد نظر یافت نشد', 1;  
		end



		UPDATE [dbo].[WorkStations]
		   SET [RetailStoreId] = @RetailStoreId
			  ,[Name] = @Name
			  ,[Location] = @Location
			  ,[IsActive] = @IsActive
		 WHERE  Id=@Id

	 end try
	 begin catch
		set @message= ERROR_MESSAGE()
        set @IsSuccessful = 0
	 end catch
	 select  @IsSuccessful IsSuccessful, @message Message
";
            migrationBuilder.Sql(PROC_UpdateWorkStations);

            var PROC_DeleteWorkStation = @"
            CREATE PROCEDURE PROC_DeleteWorkStation
@Id int
AS

	declare @IsSuccessful bit = 1 
	declare @Message nvarchar(50) = N'عملیات با موفقیت انجام شد.' 

	begin try

		if (not exists(select * from WorkStations where id=@Id))
		begin
			THROW 51000, N'شناسه مورد نظر یافت نشد', 1;  
		end
		DELETE FROM [dbo].[WorkStations]
		WHERE Id=@Id

	  end try
	  begin catch
		set @message= ERROR_MESSAGE()
        set @IsSuccessful = 0
	  end catch
	  select  @IsSuccessful IsSuccessful, @message Message
";
            migrationBuilder.Sql(PROC_DeleteWorkStation);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkStations");

            migrationBuilder.DropTable(
                name: "RetailStores");
            migrationBuilder.Sql("drop procedure PROC_AddRetailStore");
            migrationBuilder.Sql("drop procedure PROC_UpdateRetailStore");
            migrationBuilder.Sql("drop procedure PROC_DeleteRetailStore");
            migrationBuilder.Sql("drop procedure PROC_AddWorkStations");
            migrationBuilder.Sql("drop procedure PROC_UpdateWorkStations");
            migrationBuilder.Sql("drop procedure PROC_DeleteWorkStation");
        }
    }
}
