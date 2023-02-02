using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaWebEmpleados.Helpers
{
    public class MayorQueAttribute : ValidationAttribute
    {
        public MayorQueAttribute()
        {
            ErrorMessage = "El año debe ser mayor a 2000";
        }
        public override bool IsValid(object value)
        {
            //return base.IsValid(value);

            if (Convert.ToDateTime(value) < new DateTime(2000, 01, 01))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
