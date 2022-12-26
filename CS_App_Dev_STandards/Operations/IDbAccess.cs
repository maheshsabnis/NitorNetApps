using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_App_Dev_STandards.Operations
{
    public class DbOpertaionResponse<T> where T : class 
    { 
        public IEnumerable<T> Response { get; set; }
        public T Entity { get; set; }
        public string StatusMessage { get; set; }
        public int OperationStatusCode { get; set; }
    }

    /// <summary>
    /// A Generic Interface
    /// The 'T' will always be a class Type
    /// T: class is called as Generic COnstraints
    /// The 'in' will always an input parameter, the TPk 
    /// will be the typeof input parameter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IDbAccess<T, in TPk> where T : class
    {
        DbOpertaionResponse<T> GetData();
        DbOpertaionResponse<T> GetData(TPk criteria);
        DbOpertaionResponse<T> Create(T entity);
        DbOpertaionResponse<T> Update(TPk value, T entity);
        DbOpertaionResponse<T> Delete(TPk value);
    }
}
