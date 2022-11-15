using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class alterPROCUpdateWorkStations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var PROC_UpdateWorkStations = @"
            ALTER PROCEDURE [dbo].[PROC_UpdateWorkStations]
      @Id int 
	  ,@RetailStoreId uniqueidentifier
      ,@Name nvarchar(max)
      ,@Location nvarchar(max)
      ,@IsActive  bit

as

	declare @message nvarchar(50) = N'عملیات با موفقیت انجام شد'
    declare @IsSuccessful bit = 1

	begin try

		if (Not exists(select * from [WorkStations] where Id=@Id))
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
