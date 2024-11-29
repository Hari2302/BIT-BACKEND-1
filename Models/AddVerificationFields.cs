using Microsoft.EntityFrameworkCore.Migrations;

namespace FetchAPI.Models
{
    public class AddVerificationFields :Migration

    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>("VerificationCode", "Registrations", nullable: true);
            migrationBuilder.AddColumn<bool>("IsEmailVerified", "Registrations", nullable: false, defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("VerificationCode", "Registrations");
            migrationBuilder.DropColumn("IsEmailVerified", "Registrations");
        }
    }
}
