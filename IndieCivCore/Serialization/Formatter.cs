using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace IndieCivCore.Serialization
{
    public enum FormattingMethod
    {
        /// <summary>
        /// An unknown formatting method
        /// </summary>
        Unknown,

        /// <summary>
        /// Text-based XML formatting
        /// </summary>
        Xml,
        /// <summary>
        /// Binary formatting
        /// </summary>
        Binary
    }

    public abstract class Formatter : IDisposable
    {

        private bool disposed = false;
        //private Log log = Log.Core;


        /*/// <summary>
        /// [GET / SET] The de/serialization <see cref="Duality.Log"/>.
        /// </summary>
        public Log SerializationLog
        {
            get { return this.log; }
            set { this.log = value ?? new Log( "Serialize" ); }
        }*/

        /// <summary>
        /// [GET] Whether this binary serializer has been disposed. A disposed object cannot be used anymore.
        /// </summary>
        public bool Disposed
        {
            get { return this.disposed; }
        }


        protected Formatter ()
        {
            //this.AddSurrogate( new Surrogates.BitmapSurrogate() );
            //this.AddSurrogate( new Surrogates.DictionarySurrogate() );
            //this.AddSurrogate( new Surrogates.GuidSurrogate() );
        }
        ~Formatter ()
        {
            this.Dispose( false );
        }
        public void Dispose ()
        {
            GC.SuppressFinalize( this );
            this.Dispose( true );
        }
        protected virtual void Dispose ( bool manually )
        {
            this.disposed = true;
        }


        /// <summary>
        /// Returns an object indicating a "null" value.
        /// </summary>
        /// <returns></returns>
        protected virtual object GetNullObject ()
        {
            return null;
        }



        private static FormattingMethod defaultMethod = FormattingMethod.Xml;
        /// <summary>
        /// [GET / SET] The default formatting method to use, if no other is specified.
        /// </summary>
        public static FormattingMethod DefaultMethod
        {
            get { return defaultMethod; }
            set { defaultMethod = value; }
        }

        internal static void InitDefaultMethod ()
        {
            /*if ( DualityApp.ExecEnvironment == DualityApp.ExecutionEnvironment.Editor )
                defaultMethod = FormattingMethod.Xml;
            else
                defaultMethod = FormattingMethod.Binary;

            foreach ( string anyResource in Directory.GetFiles( ".", "*" + Resource.FileExt, SearchOption.AllDirectories ) )
            {
                using ( FileStream stream = File.OpenRead( anyResource ) )
                {
                    try
                    {
                        defaultMethod = XmlFormatterBase.IsXmlStream( stream ) ? FormattingMethod.Xml : FormattingMethod.Binary;
                        break;
                    }
                    catch ( Exception ) { }
                }
            }*/
        }
        /// <summary>
        /// Creates a new Formatter using the specified stream for I/O.
        /// </summary>
        /// <param name="stream">The stream to use.</param>
        /// <param name="method">
        /// The formatting method to prefer. If <see cref="FormattingMethod.Unknown"/> is specified, if the stream
        /// is read- and seekable, auto-detection is used. Otherwise, the <see cref="DefaultMethod">default formatting method</see> is used.
        /// </param>
        /// <returns>A newly created Formatter meeting the specified criteria.</returns>
        public static Formatter Create ( Stream stream, FormattingMethod method = FormattingMethod.Unknown )
        {
            /*if ( method == FormattingMethod.Unknown )
            {
                if ( stream.CanRead && stream.CanSeek && stream.Length > 0 )
                {
                    if ( XmlFormatterBase.IsXmlStream( stream ) )
                        method = FormattingMethod.Xml;
                    else
                        method = FormattingMethod.Binary;
                }
                else
                    method = defaultMethod;
            }*/

            //if ( method == FormattingMethod.Xml )
              //  return new XmlFormatter( stream );
            //else
            return new BinaryFormatter( stream );
        }

    }
}
