//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Line
    {
        public int Id { get; set; }
        public int NodeIdFrom { get; set; }
        public int NodeIdTo { get; set; }
    
        public virtual Node Node { get; set; }
        public virtual Node Node1 { get; set; }
    }
}