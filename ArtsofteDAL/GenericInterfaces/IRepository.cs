using System;
using System.Collections.Generic;
using ArtsofteDAL.Interfaces;

namespace ArtsofteDAL.GenericInterfaces
{
    public interface IRepository<T> : IRepository where T : class
    {
        /// <summary>
        /// Создание новой записи
        /// </summary>
        /// <param name="type">Создаваемый обьект</param>
        void Create(T type);
        
        /// <summary>
        /// Удаление записи по ID
        /// </summary>
        /// <param name="id">ID удаляемого обьекта</param>
        void Delete(int id);
        
        /// <summary>
        /// Прочитать запись по ее ID
        /// </summary>
        /// <param name="id">ID требуемой записи</param>
        /// <returns>Прочитанный обьект</returns>
        T Read(int id);
        
        /// <summary>
        /// Прочитать все записи в таблице
        /// </summary>
        /// <returns>Список прочитанных записей</returns>
        List<T> ReadAll();
        
        /// <summary>
        /// Обновить запись
        /// </summary>
        /// <param name="type">Обновляемый обьект</param>
        void Update(T type);
    }
}