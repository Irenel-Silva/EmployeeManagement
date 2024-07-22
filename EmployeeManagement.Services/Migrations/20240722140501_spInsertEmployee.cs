using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Services.Migrations
{
    /// <inheritdoc />
    public partial class spInsertEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"create procedure spInsertEmployee
                                @Name nvarchar(100),
                                @Email nvarchar(100),
                                @Photopath nvarchar(100),
                                @Dept int
                                as
                                Begin
	                                insert into Employees
		                                (Name, Email, PhotoPath, Department)
		                                values
			                                (@Name, @Email, @Photopath, @Dept)
                                End";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"drop procedure spInsertEmployee";
            migrationBuilder.Sql(procedure);
        }
    }
}
