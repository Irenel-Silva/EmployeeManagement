using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Services.Migrations
{
    /// <inheritdoc />
    public partial class spGetEmployeeById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure spGetEmployeeById
                                @Id int
                                as
                                Begin
                                    select * from Employees where Id=@Id
                                End";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"drop procedure spGetEmployeeById";                  
            migrationBuilder.Sql(procedure);
        }
    }
}
