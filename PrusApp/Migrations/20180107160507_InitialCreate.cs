using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PrusApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DistributionCenter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PhoneNum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributionCenter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    PackageNumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Product = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.PackageNumID);
                });

            migrationBuilder.CreateTable(
                name: "RouteNode",
                columns: table => new
                {
                    RouteNodeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Arrival = table.Column<DateTime>(nullable: false),
                    Departure = table.Column<DateTime>(nullable: false),
                    DistributionCenterID = table.Column<int>(nullable: false),
                    PackageNumID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteNode", x => x.RouteNodeID);
                    table.ForeignKey(
                        name: "FK_RouteNode_DistributionCenter_DistributionCenterID",
                        column: x => x.DistributionCenterID,
                        principalTable: "DistributionCenter",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteNode_Package_PackageNumID",
                        column: x => x.PackageNumID,
                        principalTable: "Package",
                        principalColumn: "PackageNumID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RouteNode_DistributionCenterID",
                table: "RouteNode",
                column: "DistributionCenterID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteNode_PackageNumID",
                table: "RouteNode",
                column: "PackageNumID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RouteNode");

            migrationBuilder.DropTable(
                name: "DistributionCenter");

            migrationBuilder.DropTable(
                name: "Package");
        }
    }
}
