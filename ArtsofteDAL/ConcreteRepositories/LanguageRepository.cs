using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ArtsofteDAL.GenericInterfaces;
using ArtsofteDAL.Interfaces;
using ArtsofteDAL.Models;
using Dapper;

namespace ArtsofteDAL.ConcreteRepositories
{
    public class LanguageRepository : IRepository<Language>
    {

        private readonly IDbConnection _connection;

        /// <summary>
        /// Конструктор репозитория языков
        /// </summary>
        /// <param name="connection">Текущее соединение. Зависимость установлена в Startup.</param>
        public LanguageRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        ///<inheritdoc/>
        public void Create(Language type)
        { 
            _connection.Execute("INSERT INTO Languages (Name) VALUES (@Name)", type);
        }

        ///<inheritdoc/>
        public void Delete(int id)
        { 
            _connection.Execute("DELETE FROM Languages WHERE LanguageID = @id", new {id});
        }

        ///<inheritdoc/>
        public Language Read(int id)
        {
            return _connection.Query<Language>("SELECT * FROM Languages WHERE LanguageID = @id", new {id})
                .FirstOrDefault();
        }

        ///<inheritdoc/>
        public List<Language> ReadAll()
        {
            return _connection.Query<Language>("SELECT * FROM Languages").ToList();
        }

        ///<inheritdoc/>
        public void Update(Language type)
        {
            _connection.Execute(
                "UPDATE Languages SET Name = @Name WHERE LanguageID = @LanguageID",
                type);
        }
    }
}