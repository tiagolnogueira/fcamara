namespace FCamara.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255),
                        Login = c.String(nullable: false, maxLength: 50),
                        Senha = c.String(nullable: false, maxLength: 800),
                        Token = c.String(maxLength: 4000),
                        DataExpiracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
