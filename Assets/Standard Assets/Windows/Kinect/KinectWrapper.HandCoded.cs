using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class MonoPInvokeCallbackAttribute : System.Attribute
{
	public System.Type RootType { get; set; }
	public MonoPInvokeCallbackAttribute(System.Type t) { RootType = t; }
}

namespace Windows.Foundation
{
    public struct Point
    {
    }
}

namespace Helper
{
    public static class NativeObjectCache
    {
        private static object _lock = new object();
		//字典的字典，建立类型和句柄之间的联系！！
        private static Dictionary<Type, Dictionary<IntPtr, WeakReference>> _objectCache = new Dictionary<Type, Dictionary<IntPtr, WeakReference>>();
        
        public static IntPtr MapToIUnknown(IntPtr nativePtr)
        {
            //private static Guid _guidIUnknown = new Guid("00000000-0000-0000-C000-000000000046");
            // NOTE: The IntPtr needs to use the IUnknown identity
            return nativePtr;
        }
        
        public static void AddObject<T>(IntPtr nativePtr, T obj) where T : class
        {
            lock (_lock)
            {
                Dictionary<IntPtr, WeakReference> objCache = null;
                
				if (!_objectCache.TryGetValue(typeof(T), out objCache) || objCache == null)
                {
                    objCache = new Dictionary<IntPtr, WeakReference>();
                    _objectCache[typeof(T)] = objCache;
                }
                
                objCache[nativePtr] = new WeakReference (obj);
            }
        }
        
        public static void RemoveObject<T>(IntPtr nativePtr)
        {
            lock (_lock)
            {
                Dictionary<IntPtr, WeakReference> objCache = null;
                
				if (!_objectCache.TryGetValue(typeof(T), out objCache) || objCache == null)
                {
                    objCache = new Dictionary<IntPtr, WeakReference>();
                    _objectCache[typeof(T)] = objCache;
                }
                
                if (objCache.ContainsKey(nativePtr))
                {
                    objCache.Remove(nativePtr);
                }
            }
        }
		//where T : class 是对T的限制,这里的意思是T必须是引用类型,包括任何类、接口、委托或数组类型
        public static T GetObject<T>(IntPtr nativePtr) where T : class
        {

			//锁定
            lock (_lock) 
            {
				//键和值的集合,建立关系
				//WeakReference是弱引用，其中保存的对象实例可以被GC回收掉。
				//这个类通常用于在某处保存对象引用，而又不干扰该对象被GC回收，通常用于Debug、内存监视工具等程序中。
				//因为这类程序一般要求即要观察到对象，又不能影响该对象正常的GC过程。
                Dictionary<IntPtr, WeakReference> objCache = null;
				//如果TryGetValue失败 而且 objCache 为空。即不存在改类型的句柄
                if (!_objectCache.TryGetValue(typeof(T), out objCache) || objCache == null)
                {
					//新建一个句柄
                    objCache = new Dictionary<IntPtr, WeakReference>();
                    _objectCache[typeof(T)] = objCache;
                }
                
                WeakReference reference = null;
                if (objCache.TryGetValue(nativePtr, out reference)) 
                {
                	if(reference != null)
                	{
	                    T obj = reference.Target as T; 
	                    if(obj != null)
	                    {
	                        return (T)obj;
	                    }
                    }
                }
                
                return null;
            }
        }
    }
}
