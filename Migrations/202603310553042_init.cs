namespace wateen12148MCVWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        courseId = c.Int(nullable: false, identity: true),
                        courseName = c.String(),
                        isAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.courseId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        roomId = c.Int(nullable: false, identity: true),
                        roomName = c.String(),
                        roomSize = c.Int(nullable: false),
                        isAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.roomId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        studentId = c.Int(nullable: false, identity: true),
                        studentName = c.String(),
                        studentNo = c.String(),
                    })
                .PrimaryKey(t => t.studentId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        teacherId = c.Int(nullable: false, identity: true),
                        teacherName = c.String(),
                        teacherNo = c.String(),
                    })
                .PrimaryKey(t => t.teacherId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Rooms");
            DropTable("dbo.Courses");
        }
    }
}
