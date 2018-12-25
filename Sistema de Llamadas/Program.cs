using System;

namespace Sistema_de_Llamadas
{
    class Program
    {
        static void Main( string [ ] args )
        {
            int mainResp = 0;
            int respLlamada = 0;
            int respContacto = 0;
            int cantidadLlamadas = 0;
            int cantidadContactos = 0;
            Llamada [ ] arregloLlamadas = new Llamada [ 500 ];
            Contacto [ ] arregloContactos = new Contacto [ 500 ];

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear ( );
                Console.WriteLine ( "1. Realizar Llamada" );
                Console.WriteLine ( "2. Registro de Llamadas" );
                Console.WriteLine ( "3. Contactos" );
                Console.WriteLine ( "4. Salir" );
                mainResp = int.Parse ( Console.ReadLine ( ) );

                switch ( mainResp )
                {
                    case 1:
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear ( );
                            Console.WriteLine ( "1. Ingresar Numero Telefónico" );
                            Console.WriteLine ( "2. Seleccionar de la lista de Contactos" );
                            Console.WriteLine ( "3. Regresar al menú Principal" );
                            respLlamada = int.Parse ( Console.ReadLine ( ) );
                            switch ( respLlamada )
                            {
                                case 1:
                                    String numero;
                                    Console.Clear ( );
                                    arregloLlamadas [ cantidadLlamadas ] = new Llamada ( );
                                    Console.WriteLine ( "Ingrese el Numero al que desea Llamar" );
                                    numero = Console.ReadLine ( );
                                    if ( ( numero.Length < 8 ) || ( numero.Length > 8 ) )
                                    {
                                        do
                                        {
                                            Console.Clear ( );
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine ( "El numero debe contener 8 caracteres" );
                                            Console.Write ( "Ingrese de nuevo el numero a Llamar: " );
                                            numero = Console.ReadLine ( );
                                        } while ( numero.Length != 8 );
                                    }
                                    arregloLlamadas [ cantidadLlamadas ].Contacto = new Contacto ( );
                                    arregloLlamadas [ cantidadLlamadas ].Contacto.Numero = numero;
                                    arregloLlamadas [ cantidadLlamadas ].Contacto.Nombre = "-";
                                    arregloLlamadas [ cantidadLlamadas ].Contacto.Apellido = "-";
                                    arregloLlamadas [ cantidadLlamadas ].Contacto.Correo = "-";
                                    arregloLlamadas [ cantidadLlamadas ].Fecha = DateTime.Now.ToString ( "dd/MM/yyyy" );
                                    arregloLlamadas [ cantidadLlamadas ].HoraInicio = DateTime.Now.ToString ( "hh:mm:ss" );
                                    arregloLlamadas [ cantidadLlamadas ].DateInicio = DateTime.Now;
                                    arregloLlamadas [ cantidadLlamadas ].Tipo = "Saliente";
                                    Console.Clear ( );
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine ( "Llamando a " + arregloLlamadas [ cantidadLlamadas ].Contacto.Numero + "..." );
                                    Console.WriteLine ( "Presione una tecla para finalizar la llamada" );
                                    Console.ReadKey ( );
                                    arregloLlamadas [ cantidadLlamadas ].HoraFinal = DateTime.Now.ToString ( "hh:mm:ss" );
                                    arregloLlamadas [ cantidadLlamadas ].DateFinal = DateTime.Now;
                                    arregloLlamadas [ cantidadLlamadas ].Duracion = "00:00:" + ( ( arregloLlamadas [ cantidadLlamadas ].DateFinal.Second - arregloLlamadas [ cantidadLlamadas ].DateInicio.Second ) ).ToString ( );
                                    Console.Clear ( );
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine ( "Llamada Finalizada, duracion: " + arregloLlamadas [ cantidadLlamadas ].Duracion );
                                    Console.ReadKey ( );
                                    cantidadLlamadas++;
                                    break;

                                case 2:
                                    Console.Clear ( );
                                    int contactoSeleccion = 0;
                                    if ( cantidadContactos == 0 )
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine ( "Aún no se ha agregado ningun contacto" );
                                        Console.ReadKey ( );
                                    }
                                    else
                                    {
                                        Console.WriteLine ( "Seleccione un contacto de la lista de contactos" );
                                        for ( int i = 0 ; i <= cantidadContactos - 1 ; i++ )
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write ( "Contacto #" );
                                            Console.Write ( i + 1 );
                                            Console.WriteLine ( " " );
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine ( "\tNombre: " + arregloContactos [ i ].Nombre + " "+ arregloContactos [ i ].Apellido );
                                            Console.WriteLine ( "------------------------------------------------------------------" );
                                        }
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        contactoSeleccion = int.Parse ( Console.ReadLine ( ) );
                                        //utilizacion de las funciones
                                        LlamadaContacto ( contactoSeleccion-1 );
                                    }
                                    
                                    break;
                                default:
                                    break;
                            }
                        } while ( respLlamada != 3 );
                        break;

                    case 2:
                        Console.Clear ( );
                        if(cantidadLlamadas == 0 )
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine ( "Registro de llamadas vacío" );
                            Console.ReadKey ( );
                        }
                        else
                        {
                            for ( int i = 0 ; i <= cantidadLlamadas - 1 ; i++ )
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine ( arregloLlamadas[i].Fecha +" "+arregloLlamadas[i].HoraInicio );
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine ( "\tRalizada a:\n\tNombre: " + arregloLlamadas [ i ].Contacto.Nombre + "\n\tApellido: " + arregloLlamadas [ i ].Contacto.Apellido );
                                Console.WriteLine ( "\tDuracion: " + arregloLlamadas [ i ].Duracion);
                                Console.WriteLine ( "\tNúmero de Telefono: " + arregloLlamadas [ i ].Contacto.Numero );
                                Console.WriteLine ( "\tHora de Llamada: " + arregloLlamadas [ i ].HoraInicio );
                                Console.WriteLine ( "\tFecha de Llamada: " + arregloLlamadas [ i ].Fecha );
                                Console.WriteLine ( "\tTipo de Llamada: " + arregloLlamadas [ i ].Tipo );
                                Console.WriteLine ( "------------------------------------------------------------------" );
                            }
                            Console.ReadKey ( );
                        }
                        break;

                    case 3:
                        Console.Clear ( );
                        Console.WriteLine ( "1. Agregar Nuevo Contacto" );
                        Console.WriteLine ( "2. Listar todos los Contactos" );
                        respContacto = int.Parse ( Console.ReadLine ( ) );
                        switch ( respContacto )
                        {
                            case 1:
                                Console.Clear ( );
                                arregloContactos [ cantidadContactos ] = new Contacto ( );
                                Console.WriteLine ( "Ingrese el Nombre para el contacto #" );
                                Console.Write ( cantidadContactos + 1 );
                                Console.WriteLine ( " " );
                                arregloContactos [ cantidadContactos ].Nombre = Console.ReadLine ( );
                                Console.WriteLine ( "Ingrese el Apellido" );
                                arregloContactos [ cantidadContactos ].Apellido = Console.ReadLine ( );
                                Console.WriteLine ( "Ingrese el Número Telefónico" );
                                arregloContactos [ cantidadContactos ].Numero = Console.ReadLine ( );
                                if ( arregloContactos [ cantidadContactos ].Numero.Length < 8 || arregloContactos [ cantidadContactos ].Numero.Length > 8 )
                                {
                                    do
                                    {
                                        Console.Clear ( );
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine ( "El numero debe contener 8 caracteres" );
                                        Console.Write ( "Ingrese de nuevo el numero telefonico: " );
                                        arregloContactos [ cantidadContactos ].Numero = Console.ReadLine ( );
                                    } while ( arregloContactos [ cantidadContactos ].Numero.Length != 8 );
                                }
                                Console.WriteLine ( "Ingrese el correo" );
                                arregloContactos [ cantidadContactos ].Correo = Console.ReadLine ( );
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Clear ( );
                                Console.WriteLine ( "Contacto agregado correactamente!" );
                                Console.ReadKey ( );
                                cantidadContactos++;
                                break;
                            case 2:
                                Console.Clear ( );
                                if ( cantidadContactos == 0 )
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine ( "Aún no se ha agregado ningun contacto" );
                                    Console.ReadKey ( );
                                }
                                else
                                {
                                    for ( int i = 0 ; i <= cantidadContactos-1 ; i++ )
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine ( "Contacto #" );
                                        Console.Write ( i + 1 );
                                        Console.WriteLine ( " " );
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine ( "\tNombre: " + arregloContactos [ i ].Nombre );
                                        Console.WriteLine ( "\tApellido: " + arregloContactos [ i ].Apellido );
                                        Console.WriteLine ( "\tCorreo: " + arregloContactos [ i ].Correo );
                                        Console.WriteLine ( "\tNúmero: " + arregloContactos [ i ].Numero );
                                        Console.WriteLine ( "------------------------------------------------------------------" );
                                    }
                                    Console.ReadKey ( );
                                }
                                break;
                        }
                        break;

                    default:
                        break;
                }
            } while ( mainResp != 4 );
            //se comienza a hacer uso de las funciones
            void LlamadaContacto( int contactoSeleccion )
            {
                Console.Clear ( );
                arregloLlamadas [ cantidadLlamadas ] = new Llamada ( );
                arregloLlamadas [ cantidadLlamadas ].Contacto = new Contacto ( );
                arregloLlamadas [ cantidadLlamadas ].Contacto = arregloContactos [ contactoSeleccion ];
                arregloLlamadas [ cantidadLlamadas ].Fecha = DateTime.Now.ToString ( "dd/MM/yyyy" );
                arregloLlamadas [ cantidadLlamadas ].HoraInicio = DateTime.Now.ToString ( "hh:mm:ss" );
                arregloLlamadas [ cantidadLlamadas ].DateInicio = DateTime.Now;
                arregloLlamadas [ cantidadLlamadas ].Tipo = "Saliente";
                Console.Clear ( );
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine ( "Llamando a " + arregloLlamadas [ cantidadLlamadas ].Contacto.Nombre+" "+ arregloLlamadas [ cantidadLlamadas ].Contacto.Apellido + "..." );
                Console.WriteLine ( "Presione una tecla para finalizar la llamada" );
                Console.ReadKey ( );
                arregloLlamadas [ cantidadLlamadas ].HoraFinal = DateTime.Now.ToString ( "hh:mm:ss" );
                arregloLlamadas [ cantidadLlamadas ].DateFinal = DateTime.Now;
                arregloLlamadas [ cantidadLlamadas ].Duracion = "00:00:" + ( ( arregloLlamadas [ cantidadLlamadas ].DateFinal.Second - arregloLlamadas [ cantidadLlamadas ].DateInicio.Second ) ).ToString ( );
                Console.Clear ( );
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine ( "Llamada Finalizada, duracion: " + arregloLlamadas [ cantidadLlamadas ].Duracion );
                Console.ReadKey ( );
                cantidadLlamadas++;
            }
        }
        
    }

    public class Contacto
    {
        private String nombre;
        private String apellido;
        private String correo;
        private String numero;

        public Contacto() { }

        public String Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }

        public String Apellido
        {
            set { apellido = value; }
            get { return apellido; }
        }

        public String Correo
        {
            set { correo = value; }
            get { return correo; }
        }

        public String Numero
        {
            set { numero = value; }
            get { return numero; }
        }
    }

    public class Llamada
    {
        private String horaInicio;
        private String horaFinal;
        private DateTime dateInicio;
        private DateTime dateFinal;
        private String fecha;
        private String duracion;
        private String tipo;
        private Contacto contacto;

        public Llamada() { }

        public String HoraInicio
        {
            set { horaInicio = value; }
            get { return horaInicio; }
        }

        public DateTime DateInicio
        {
            set { dateInicio = value; }
            get { return dateInicio; }
        }

        public DateTime DateFinal
        {
            set { dateFinal = value; }
            get { return dateFinal; }
        }

        public String HoraFinal
        {
            set { horaFinal = value; }
            get { return horaFinal; }
        }

        public String Fecha
        {
            set { fecha = value; }
            get { return fecha; }
        }

        public String Duracion
        {
            set { duracion = value; }
            get { return duracion; }
        }

        public String Tipo
        {
            set { tipo = value; }
            get { return tipo; }
        }

        public Contacto Contacto
        {
            set { contacto = value; }
            get { return contacto; }
        }
    }
}
