using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApi.Migrations
{
    /// <inheritdoc />
    public partial class updateinitialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "1IXZqxodJQDr0NBqFRFGdb7oUyFcai/YbdcJQdLSsGo=", "WHaKSrj/Oce7qfCdLhxSig==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "vGgjmh1EIyo2pOiMFlQd9h+JRpMLL8YKRIPAf45uypA=", "y25pCISAEdMr/G1R4MKAUQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "0zZk8tCXsDzVG1+pzSOYjlYj0UCwkEM36N+cWGQLAXc=", "a5+BxCFkPJpSSDslk83tdw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "jDZRBAVARZNNfsIsfU/wqZUY7cQPQjCyWg3HW1Uuovw=", "MVlsFsGZa1FUWc24WDZycQ==" });
        }
    }
}
