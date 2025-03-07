﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECMS;

namespace ECMS.WebPage
{
    public class Settings
    {
        private Check __Check = new Check();
        private string _Get_StringValue_Settings(int ID)
        {
            return __Check.stringCheck("select Value_String from System_Settings where SettingsID="+ID);
        }
        private string _Get_StringValue_Settings(string SettingsName)
        {
            return __Check.stringCheck("select Value_String from System_Settings where SettingsName='" + SettingsName+"'");
        }
        private bool _Get_BoolValue_Settings(int ID)
        {
            var returnValue = __Check.stringCheck("select Value_Bool from System_Settings where SettingsID=" + ID);
            return returnValue == "True" || returnValue == "true" ? true : false;
        }
        private bool _Get_BoolValue_Settings(string SettingsName)
        {
            var returnValue = __Check.stringCheck("select Value_Bool from System_Settings where SettingsName='" + SettingsName + "'");
            return returnValue == "True" || returnValue == "true" ? true : false;
        }
        private int _Get_IntValue_Settings(int ID)
        {
            return __Check.int32Check("select Value_Int from System_Settings where SettingsID=" + ID);
        }
        private int _Get_IntValue_Settings(string SettingsName)
        {
            return __Check.int32Check("select Value_Int from System_Settings where SettingsName='" + SettingsName + "'");
        }
        private double _Get_DoubleValue_Settings(int ID)
        {
            var ReturnValue = Convert.ToDouble(__Check.stringCheck("select Value_Float from System_Settings where SettingsID=" + ID));
            return ReturnValue; 
        }
        private double _Get_DoubleValue_Settings(string SettingsName)
        {
            var ReturnValue = Convert.ToDouble(__Check.stringCheck("select Value_Float from System_Settings where SettingsName='" + SettingsName + "'"));

            return ReturnValue;
        }
        private string _Get_Discription(int ID)
        {
            return __Check.stringCheck("select Discription from System_Settings where SettingsID=" + ID);
        }
        private string _Get_Discription(string SettingsName)
        {
            return __Check.stringCheck("select Discription from System_Settings where SettingsName='" + SettingsName + "'");
        }
        private DateTime _Get_DateTimeValue_Settings(int ID)
        {
            return Convert.ToDateTime(__Check.stringCheck("select Value_DateTime from System_Settings where SettingsID=" + ID));
        }
        private DateTime _Get_DateTimeValue_Settings(string SettingsName)
        {
            return Convert.ToDateTime(__Check.stringCheck("select Value_DateTime from System_Settings where SettingsName='" + SettingsName + "'"));
        }
        private object _GetValue(int ID)
        {
            var Value_Type = __Check.stringCheck("select Value_Type from System_Settings where SettingsID=" + ID);
            if(Value_Type== "Int" ||Value_Type=="int")
            {
                return __Check.int32Check("select Value_Int from System_Settings where SettingsID=" + ID);
            }
            else if(Value_Type == "Float" || Value_Type == "float")
            {
                return Convert.ToDouble(__Check.stringCheck("select Value_Float from System_Settings where SettingsID=" + ID));
            }
            else if(Value_Type == "String" || Value_Type == "string")
            {
                return __Check.int32Check("select Value_String from System_Settings where SettingsID=" + ID);
            }
            else if(Value_Type == "Bool" || Value_Type == "bool")
            {
                var returnValue = __Check.stringCheck("select Value_Bool from System_Settings where SettingsID=" + ID);
                return returnValue == "True" || returnValue == "true" ? true : false;
            }
            else if(Value_Type == "DateTime" || Value_Type == "datetime")
            {
                return Convert.ToDateTime(__Check.stringCheck("select Value_DateTime from System_Settings where SettingsID=" + ID));
            }
            else
            {
                return __Check.stringCheck("select Value_Int from System_Settings where SettingsID=" + ID)+
                    __Check.stringCheck("select Value_Float from System_Settings where SettingsID=" + ID)+
                    __Check.stringCheck("select Value_String from System_Settings where SettingsID=" + ID)+
                    __Check.stringCheck("select Value_Bool from System_Settings where SettingsID=" + ID)+
                    __Check.stringCheck("select Value_DateTime from System_Settings where SettingsID=" + ID);
            }

        }
        private object _GetValue(string SettingsName)
        {
            var Value_Type = __Check.stringCheck("select Value_Type from System_Settings where SettingsName='" + SettingsName + "'");
            if (Value_Type == "Int" || Value_Type == "int")
            {
                return __Check.int32Check("select Value_Int from System_Settings where SettingsName='" + SettingsName + "'");
            }
            else if (Value_Type == "Float" || Value_Type == "float")
            {
                return Convert.ToDouble(__Check.stringCheck("select Value_Float from System_Settings where SettingsName='" + SettingsName + "'"));
            }
            else if (Value_Type == "String" || Value_Type == "string")
            {
                return __Check.int32Check("select Value_String from System_Settings where SettingsName='" + SettingsName + "'");
            }
            else if (Value_Type == "Bool" || Value_Type == "bool")
            {
                var returnValue = __Check.stringCheck("select Value_Bool from System_Settings where SettingsName='" + SettingsName + "'");
                return returnValue == "True" || returnValue == "true" ? true : false;
            }
            else if (Value_Type == "DateTime" || Value_Type == "datetime")
            {
                return Convert.ToDateTime(__Check.stringCheck("select Value_DateTime from System_Settings where SettingsName='" + SettingsName + "'"));
            }
            else
            {
                return  __Check.stringCheck("select Value_Int from System_Settings where SettingsName='" + SettingsName + "'") +
                        __Check.stringCheck("select Value_Float from System_Settings where SettingsName='" + SettingsName + "'") +
                        __Check.stringCheck("select Value_String from System_Settings where SettingsName='" + SettingsName + "'") +
                        __Check.stringCheck("select Value_Bool from System_Settings where SettingsName='" + SettingsName + "'") +
                        __Check.stringCheck("select Value_DateTime from System_Settings where SettingsName='" + SettingsName + "'");
            }
        }




        /// <summary>
        /// This is a geting any valu to value type setting.
        /// </summary>
        /// <param name="ID">need settings id</param>
        /// <returns>return any data to setting value type.</returns>
        public object GetValue(int ID)
        { return _GetValue(ID); }
        /// <summary>
        /// This is a geting any valu to value type setting.
        /// </summary>
        /// <param name="SettingsName">need settings Name</param>
        /// <returns>return any data to setting value type.</returns>
        public object GetValue(string SettingsName)
        { return _GetValue(SettingsName); }
        /// <summary>
        /// DateTime value show in Settings Get_DateTimeValue_Settings() function.
        /// </summary>
        /// <param name="ID">Finding Settings in ID Index.</param>
        /// <returns>DateTime Value</returns>
        public DateTime Get_DateTimeValue_Settings(int ID)
        {
            return _Get_DateTimeValue_Settings(ID);
        }
        /// <summary>
        /// DateTime value show in Settings Get_DateTimeValue_Settings() function.
        /// </summary>
        /// <param name="SettingsName">Finding Settings in SettingsName Index.</param>
        /// <returns>DateTime Value</returns>
        public DateTime Get_DateTimeValue_Settings(string SettingsName)
        {
            return _Get_DateTimeValue_Settings(SettingsName);
        }
        /// <summary>
        /// String Value show in Settings Get_Discription() function.
        /// </summary>
        /// <param name="ID">Finding Settings in ID Index.</param>
        /// <returns>String Value</returns>
        public string Get_Discription(int ID)
        {
            return _Get_Discription(ID);
        }
        /// <summary>
        /// String Value show in Settings Get_Discription() function.
        /// </summary>
        /// <param name="SettingsName">Finding Settings in SettingsName Index.</param>
        /// <returns>String Value</returns>
        public string Get_Discription(string SettingsName)
        {
            return _Get_Discription(SettingsName);
        }
        /// <summary>
        /// Double Value show in Settings Get_DoubleValue_Settings) function.
        /// </summary>
        /// <param name="ID">Finding Settings in ID Index.</param>
        /// <returns>Double Value</returns>
        public double Get_DoubleValue_Settings(int ID)
        { return _Get_DoubleValue_Settings(ID); }
        /// <summary>
        /// Double Value show in Settings Get_DoubleValue_Settings() function.
        /// </summary>
        /// <param name="SettingsName">Finding Settings in SettingsName Index.</param>
        /// <returns>Double Value</returns>
        public double Get_DoubleValue_Settings(string SettingsName)
        { return _Get_DoubleValue_Settings(SettingsName); }
        /// <summary>
        /// Integer Value show in Settings Get_InValue_Settings() function.
        /// </summary>
        /// <param name="ID">Finding Settings in ID Index.</param>
        /// <returns>Integer Value</returns>
        public int Get_InValue_Settings(int ID)
        { return _Get_IntValue_Settings(ID); }
        /// <summary>
        /// Integer Value show in Settings Get_InValue_Settings() function.
        /// </summary>
        /// <param name="SettingsName">Finding Settings in SettingsName Index.</param>
        /// <returns>Integer Value</returns>
        public int Get_InValue_Settings(string SettingsName)
        { return _Get_IntValue_Settings(SettingsName); }
        /// <summary>
        /// Boolean Value  show in Settings Get_BoolValue_Settings() function.
        /// </summary>
        /// <param name="ID">Finding Settings in ID Index.</param>
        /// <returns>Boolean Value</returns>
        public bool Get_BoolValue_Settings(int ID)
        { return _Get_BoolValue_Settings(ID); }
        /// <summary>
        /// Boolean Value  show in Settings Get_BoolValue_Settings() function.
        /// </summary>
        /// <param name="SettingsName">Finding Settings in SettingsName Index.</param>
        /// <returns>Boolean Value</returns>
        public bool Get_BoolValue_Settings(string SettingsName)
        { return _Get_BoolValue_Settings(SettingsName); }
        /// <summary>
        /// String Value show in Settings Get_StringValue_Settings() function .
        /// </summary>
        /// <param name="ID">Finding Settings in ID Index.</param>
        /// <returns>String Value</returns>
        public string Get_StringValue_Settings(int ID)
        {
            return _Get_StringValue_Settings(ID);
        }
        /// <summary>
        /// String Value show in Settings Get_StringValue_Settings() function.
        /// </summary>
        /// <param name="SettingsName">Finding Settings in SettingsName Index.</param>
        /// <returns>String Value</returns>
        public string Get_StringValue_Settings(string SettingsName)
        {
            return _Get_StringValue_Settings(SettingsName);
        }





    }



}
