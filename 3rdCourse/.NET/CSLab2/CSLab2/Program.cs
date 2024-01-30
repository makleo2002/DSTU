
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

[AttributeUsage(AttributeTargets.Method|AttributeTargets.Field|AttributeTargets.Property)]
public class CommandLineAttribute : Attribute
{
    public string CommandSwitch { get; set; }
    public CommandLineAttribute() {
        CommandSwitch = " ";
    }
    public CommandLineAttribute(string name)
    {
        this.CommandSwitch = name;
    }
 
}

class Commands
{
    [CommandLine] public bool IpConfig;
    [CommandLine] public bool GetMac;
    [CommandLine] public bool Netstat;
    [CommandLine] public string Pathping { get; set; }

    [CommandLine]
    public void ping(string address)
    {
        Console.WriteLine("Ping:");
        Process.Start("ping", address).WaitForExit();
        Console.WriteLine();
    }

    [CommandLine]
    public void tracert(string address)
    {
        Console.WriteLine("Tracert:");
        Process.Start("tracert", address).WaitForExit();
        Console.WriteLine();
    }
}

class CMD
{
   
    public static T ParseCommandLine<T>(string[] args) where T : new()
    {
        Type type = typeof(T);
        T obj = new T();
       
        bool found = false;
        string command="";
        string value;

        var Members = type.GetMembers();

        for(int m = 0; m < args.Length;m++)
        {
          
            for (int i = 0; i < Members.Length; i++)
            {
              
                if (!args[m].Contains("="))
                {
                    command=args[m].Substring(1);
                    value = "true";
                }
                else 
                {
                    command = args[m].Substring(1, args[m].IndexOf('=') - 1);
                    value = args[m].Substring(args[m].IndexOf('=') + 1);
                }
             
           
                if (Members[i].Name == command)
                {
                    
                    found = true;
                    switch (Members[i].MemberType)
                    {
                        case MemberTypes.Field:
                            {
                              
                                FieldInfo field = Members[i] as FieldInfo;
                               
                                var fieldType = field.FieldType;
                                // Проверяем, входит ли тип поля в список допустимых для командной строки типов данных
                                if (fieldType == typeof(int) || fieldType == typeof(double) || fieldType == typeof(bool) || fieldType == typeof(string))
                                {
                                    Console.WriteLine("Type is valid");
                                }
                                else
                                {
                                    Console.WriteLine("Type isn't valid");
                                    break;
                                }

                                object convertedValue = null;
                                try
                                {
                                    // Пытаемся провести преобразование строкового представления значения параметра командной строки к типу данных поля
                                    convertedValue = Convert.ChangeType(value, fieldType);
                                }
                                catch (Exception ex)
                                {
                                    // Если такое преобразование невозможно, генерируем исключение InvalidCastException
                                    throw new InvalidCastException($"Cannot convert value '{value}' to type {fieldType.FullName}.", ex);
                                }

    // Используем рефлексию, чтобы присвоить значение преобразованного значения параметра полю объекта
    ((FieldInfo)Members[i]).SetValue(obj, convertedValue);
                                Console.WriteLine(field.Name+":");
                                  Process.Start(field.Name).WaitForExit();
                                Console.WriteLine();
                              
                            }
                            break;
                        case MemberTypes.Property:
                            {
                                
                                PropertyInfo property = Members[i] as PropertyInfo;
                                var propertyType = property.PropertyType;
                                if (propertyType == typeof(int) || propertyType == typeof(double) ||
                                    propertyType == typeof(bool) || propertyType == typeof(string))
                                {
                                    Console.WriteLine("Type is valid");
                                }
                                else
                                {
                                    Console.WriteLine("Type isn't valid");
                                }

                                object convertedValue = null;
                                try
                                {
                                    // Пытаемся провести преобразование строкового представления значения параметра командной строки к типу данных поля
                                    convertedValue = Convert.ChangeType(value, propertyType);
                                }
                                catch (Exception ex)
                                {
                                    // Если такое преобразование невозможно, генерируем исключение InvalidCastException
                                    throw new InvalidCastException($"Cannot convert value '{value}' to type {propertyType.FullName}.", ex);
                                }
                                if (!property.CanWrite)
                                {
                                    throw new InvalidOperationException();
                                }
                                property.SetValue(obj, convertedValue);
                                Console.WriteLine(property.Name + ":");
                                Process.Start(property.Name).WaitForExit();
                                Console.WriteLine();
                            }
                            break;
                        case MemberTypes.Method:
                            {
                              
                                var methodInfo = type.GetMethod(command);

                                if (methodInfo == null)
                                {
                                    throw new InvalidOperationException($"Method {value} not found.");
                                }

                                var parameters = methodInfo.GetParameters();



                                if (parameters.Length != 1 || (parameters[0].ParameterType != typeof(int) && (parameters[0].ParameterType != typeof(double))
                                    && (parameters[0].ParameterType != typeof(bool)) && (parameters[0].ParameterType != typeof(string))))
                                {
                                    throw new InvalidOperationException($"Method {args[1]} must have exactly one parameter of valid type.");
                                }

                                object convertedValue = null;
                                try
                                {
                                    // Пытаемся провести преобразование строкового представления значения параметра командной строки к типу данных поля
                                    convertedValue = Convert.ChangeType(value, parameters[0].ParameterType);
                                }
                                catch (Exception ex)
                                {
                                    // Если такое преобразование невозможно, генерируем исключение InvalidCastException
                                    throw new InvalidCastException($"Cannot convert value '{value}' to type {parameters[0].ParameterType.FullName}.", ex);
                                }
                                methodInfo.Invoke(obj, new object[] { convertedValue });
                            }
                            break;
                    }
                }
            }

        }

        if (!found) throw new ArgumentException(String.Format("Command", command,"isn't found"), "num");

        return obj;
    }
}

class Program
{
    static void Main(string[] args)
    {

         CMD.ParseCommandLine<Commands>(new string[4] { "-IpConfig", "-Pathping" , "-ping=www.google.com", "-tracert=www.google.com"});
    }
}




