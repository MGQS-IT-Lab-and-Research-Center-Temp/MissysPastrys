using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissysPastrys.Migrations
{
    /// <inheritdoc />
    public partial class Primo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    CategoryName = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleName = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: false),
                    HashSalt = table.Column<string>(type: "longtext", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false),
                    State = table.Column<string>(type: "longtext", nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderPlacedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OrderDeliveryDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "longtext", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pastries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    ShortDescription = table.Column<string>(type: "longtext", nullable: false),
                    ImageThumbnailUrl = table.Column<string>(type: "longtext", nullable: false),
                    LongDescription = table.Column<string>(type: "longtext", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<string>(type: "varchar(255)", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pastries_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    OrderId = table.Column<string>(type: "varchar(255)", nullable: false),
                    PastryId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Pastries_PastryId",
                        column: x => x.PastryId,
                        principalTable: "Pastries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PastryCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    CategoryId = table.Column<string>(type: "varchar(255)", nullable: false),
                    PastryId = table.Column<string>(type: "varchar(255)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastryCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PastryCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PastryCategories_Pastries_PastryId",
                        column: x => x.PastryId,
                        principalTable: "Pastries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    PastryId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ReviewText = table.Column<string>(type: "longtext", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Pastries_PastryId",
                        column: x => x.PastryId,
                        principalTable: "Pastries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    PastryId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "varchar(255)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Pastries_PastryId",
                        column: x => x.PastryId,
                        principalTable: "Pastries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    ShoppingCartItemId = table.Column<string>(type: "varchar(255)", nullable: false),
                    DeliveryGroup = table.Column<string>(type: "longtext", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "longtext", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_ShoppingCartItems_ShoppingCartItemId",
                        column: x => x.ShoppingCartItemId,
                        principalTable: "ShoppingCartItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_ShoppingCartItemId",
                table: "Deliveries",
                column: "ShoppingCartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_PastryId",
                table: "OrderDetails",
                column: "PastryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pastries_OrderId",
                table: "Pastries",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PastryCategories_CategoryId",
                table: "PastryCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PastryCategories_PastryId",
                table: "PastryCategories",
                column: "PastryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PastryId",
                table: "Reviews",
                column: "PastryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_PastryId",
                table: "ShoppingCartItems",
                column: "PastryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCartId",
                table: "ShoppingCartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "PastryCategories");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Pastries");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
