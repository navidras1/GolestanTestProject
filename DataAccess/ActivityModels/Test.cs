using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ActivityModels
{
    internal class Test
    {
        //        string PROC_AddRetailStore = @"
        //        CREATE PROCEDURE PROC_AddRetailStore 
        //@Name nvarchar(500),
        //@Address nvarchar(500),
        //@IPAddress varchar(15),
        //@OpeningDate datetime,
        //@IsActive bit,
        //@IsTell bit

        //as

        // declare @newId nvarchar(50)
        // declare @message nvarchar(50) = N'عملیات با موفقیت انجام شد'
        // begin try

        // IF EXISTS(SELECT * FROM [RetailStores] WHERE [Name]=@Name)
        // begin
        //	THROW 51000, N'نام شعبه از قبل موجود است', 1;  
        // end


        // set @newId = NEWID();
        //INSERT INTO [dbo].[RetailStores]
        //           ([Id]
        //           ,[Name]
        //           ,[Address]
        //           ,[IPAddress]
        //           ,[OpeningDate]
        //           ,[IsActive]
        //           ,[IsTell]
        //           )
        //     VALUES
        //           (@newId
        //           ,@Name
        //           ,@Address
        //           ,@IPAddress
        //           ,@OpeningDate
        //           ,@IsActive
        //           ,@IsTell
        //           )

        //end try
        //begin catch

        //	set @message= ERROR_MESSAGE()
        //end catch
        // select  1 Id , @newId TheId, @message Message

        //GO
        //";
        //        migrationBuilder.Sql(PROC_AddRetailStore);
        //migrationBuilder.Sql("drop procedure PROC_AddRetailStore");




//        string PROC_UpdateRetailStore = @"
//       CREATE PROCEDURE PROC_UpdateRetailStore
//	   @Id uniqueidentifier
//      ,@Name  nvarchar(max)
//      ,@Address  nvarchar(max)
//      ,@Ipaddress  nvarchar(max)
//      ,@OpeningDate datetime2(7)
//      ,@IsActive bit
//	  ,@IsTell bit
      
//as
	
	
//	declare @message nvarchar(50) = N'عملیات با موفقیت انجام شد'
//    declare @IsSuccessful bit = 1
//	begin try

//	UPDATE [dbo].[RetailStores]
//	   SET [Name] = @Name
//		  ,[Address] = @Address
//		  ,[Ipaddress] = @Ipaddress
//		  ,[OpeningDate] = @OpeningDate
//		  ,[IsActive] = @IsActive
//		  ,[IsTell] = @IsTell
      
//	 WHERE Id=@Id

//	 end try
//	 begin catch
//		set @message= ERROR_MESSAGE()
//        set @IsSuccessful = 0
//	 end catch
//	 select  @IsSuccessful IsSuccessful, @message Message
//            ";
//        migrationBuilder.Sql(PROC_UpdateRetailStore);
    }
}
