using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreSP.Migrations
{
    /// <inheritdoc />
    public partial class S001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE PROCEDURE dbo.Person_Add
(
	@name nvarchar(max),
	@id int OUTPUT
)	
AS
BEGIN
	SET     NOCOUNT ON;
	INSERT  INTO Persons(Name)
	VALUES  (@name)
    SELECT  @id = SCOPE_IDENTITY()
END
            ");

            migrationBuilder.Sql(@"
CREATE PROCEDURE dbo.Person_GetBy_Id
(
	@id int
)	
AS
BEGIN
    SELECT  Id, Name
	FROM    Persons
    WHERE   Id = @id
END"
            );

            migrationBuilder.Sql(@"
CREATE PROCEDURE dbo.Person_Get_Id
AS
BEGIN
    SELECT  Id
    FROM    Persons
END"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.Person_Add");
            migrationBuilder.Sql("DROP PROCEDURE dbo.Person_GetBy_Id");
            migrationBuilder.Sql("DROP PROCEDURE dbo.Person_Get_Id");
        }
    }
}
