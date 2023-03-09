using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyCacheHelper
{
    public sealed class ThreadSafeList<T> 
    { 
        private readonly IList<T> list = new List<T>(); 
        private readonly object lockable = new object(); 
        
        public void Add(T t) 
        { 
            lock (lockable) 
            { 
                list.Add(t); 
            } 
        } 
        
        public IList<T> GetSnapshot() 
        { 
            IList<T> result; 
            
            lock (lockable) 
            { 
                result = new List<T>(list); 
            } 
            return result; 
        } 
    } 
}
