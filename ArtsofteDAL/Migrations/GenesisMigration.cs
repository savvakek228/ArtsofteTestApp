using System.Data;
using FluentMigrator;
using FluentMigrator.SqlServer;

namespace ArtsofteDAL.Migrations
{
    [Migration(20200510000001)]
    public class GenesisMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Departments")
                .WithColumn("DepartmentID").AsInt16().PrimaryKey().Identity(1, 1)
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Floor").AsInt16().NotNullable();
            Create.Table("Languages")
                .WithColumn("LanguageID").AsInt16().PrimaryKey().Identity(1, 1)
                .WithColumn("Name").AsString(50).NotNullable();
            Create.Table("Employees")
                .WithColumn("EmployeeID").AsInt16().PrimaryKey().Identity(1, 1)
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Surname").AsString(50).NotNullable()
                .WithColumn("Age").AsInt16().NotNullable()
                .WithColumn("Gender").AsBoolean().NotNullable()
                .WithColumn("DepartmentID").AsInt16().NotNullable()
                .WithColumn("LanguageID").AsInt16().NotNullable();
            Create.ForeignKey("FK_Departments_To_Employees")
                .FromTable("Employees")
                .ForeignColumn("DepartmentID")
                .ToTable("Departments")
                .PrimaryColumn("DepartmentID")
                .OnDeleteOrUpdate(Rule.Cascade);
            Create.ForeignKey("FK_Languages_To_Employees")
                .FromTable("Employees")
                .ForeignColumn("LanguageID")
                .ToTable("Languages")
                .PrimaryColumn("LanguageID")
                .OnDeleteOrUpdate(Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("Employees");
            Delete.Table("Departments");
            Delete.Table("Languages");
        }
    }
}