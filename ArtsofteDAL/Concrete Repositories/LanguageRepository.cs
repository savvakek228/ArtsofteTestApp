using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ArtsofteDAL.Base_Classes;
using ArtsofteDAL.Generic_Interfaces;
using ArtsofteDAL.Interfaces;
using ArtsofteDAL.POCO_Entities;
using Dapper;

namespace ArtsofteDAL.Concrete_Repositories
{
    public class LanguageRepository : RepositoryBase<Language>
    {
        public IDbConnection Connection => new SqlConnection(@"Server=LAPTOP-RNC7R08Q\SQLExpress;Database=EmployeesDB;Trusted_Connection=true");

        public LanguageRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Connection.Open();
        }
        
        public override void Create(Language type) 
            => Connection.Execute("INSERT INTO Languages (EmployeeID, Name) VALUES (@EmployeeID,@Name)",type);

        public override void Delete(int id)
            => Connection.Execute("DELETE FROM Languages WHERE LanguageID = @id", new {id});

        public override Language Read(int id) =>
            Connection.Query<Language>("SELECT * FROM Languages WHERE LanguageID = @id", new {id})
                .FirstOrDefault();

        public override List<Language> ReadAll()
            => Connection.Query<Language>("SELECT * FROM Languages").ToList();

        public override void Update(Language type) =>
            Connection.Execute(
                "UPDATE Languages SET EmployeeID = @EmployeeID, Name = @Name WHERE LanguageID = @LanguageID",
                type);
    }
}