using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Szk3.Company.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAddressCountryToExternalId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "CompanyAddress",
                newName: "CountryDisplay");

            migrationBuilder.AddColumn<int>(
                name: "CountryExternalId",
                table: "CompanyAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryExternalId",
                table: "CompanyAddress");

            migrationBuilder.RenameColumn(
                name: "CountryDisplay",
                table: "CompanyAddress",
                newName: "Country");
        }
    }
}
