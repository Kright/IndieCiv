using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace IndieCivCore.Resources
{
	public interface IResourceRef
	{
		string Path { get; set; }

        Type ResType { get; }
	}

	public struct ResourceRef<T> : IEquatable<ResourceRef<T>>, IResourceRef where T : Resource
	{
        [DebuggerBrowsable( DebuggerBrowsableState.Never )]
        public static readonly ResourceRef<T> Null = new ResourceRef<T>( null );

		private T contentInstance;
		private string contentPath;

        public T Res
        {
            get
            {
                //if ( this.contentInstance == null || this.contentInstance.Disposed ) this.RetrieveInstance();
                return this.contentInstance;
            }
            set
            {
                this.contentPath = value == null ? null : value.Path;
                this.contentInstance = value;
            }
        }

        public Type ResType
        {
            get
            {
				return this.contentInstance.GetType();
                /*if ( this.contentInstance != null && !this.contentInstance.Disposed ) return this.contentInstance.GetType();

                Type result = Resource.GetTypeByFileName( this.contentPath );
                if ( result != null ) return result;

                //this.RetrieveInstance();
                if ( this.contentInstance != null && !this.contentInstance.Disposed ) return this.contentInstance.GetType();

                return null;*/
            }
        }

        public string Path
        {
            get { return this.contentPath; }
            set
            {
                this.contentPath = value;
                if ( this.contentInstance != null && this.contentInstance.Path != value )
                    this.contentInstance = null;
            }
        }

        public ResourceRef ( T res, string altPath )
		{
			this.contentInstance = res;
			if (res != null && !String.IsNullOrEmpty(res.Path))
				this.contentPath = res.Path;
			else 
				this.contentPath = altPath;
		}

		public ResourceRef( T res )
		{
			this.contentInstance = res;
			this.contentPath = (res != null) ? res.Path : null;
		}

        public override bool Equals ( object obj )
        {
            if ( obj is ResourceRef<T> )
                return this == ( ResourceRef<T> ) obj;
            else
                return base.Equals( obj );
        }
		public bool Equals( ResourceRef<T> other )
		{
			return this == other;
		}

		public static implicit operator ResourceRef<T>( T res )
		{
			return new ResourceRef<T>( res );
		}
        public static explicit operator T ( ResourceRef<T> res )
        {
            return res.Res;
        }

		public static bool operator ==( ResourceRef<T> first, ResourceRef<T> second )
		{
			return true;
		}

		public static bool operator !=( ResourceRef<T> first, ResourceRef<T> second )
		{
			return !( first == second );
		}

        public override int GetHashCode ()
        {
            if ( this.contentPath != null ) return this.contentPath.GetHashCode();
            else if ( this.contentInstance != null ) return this.contentInstance.GetHashCode();
            else return 0;
        }

	}

	public static class ResourceProvider
	{
		public const string VirtualResourcePath = "";

        private static Dictionary<string, Resource> resLibrary = new Dictionary<string, Resource>();
		private static List<Resource> defaultContent = new List<Resource>();

        //public static event EventHandler ResourceRegistered = null;

        public static void AddResource ( string path, Resource resource )
        {
            if ( String.IsNullOrEmpty( path ) ) return;
            if ( String.IsNullOrEmpty( resource.Path ) ) resource.Path = path;
            resLibrary [ path ] = resource;
        }

        public static ResourceRef<T> RequestResource<T> ( string path ) where T : Resource
        {
            if ( String.IsNullOrEmpty( path ) ) return null;

            Resource res;
            if ( resLibrary.TryGetValue ( path, out res ) )
                return new ResourceRef<T>( res as T, path );

            return new ResourceRef<T>( LoadContent( path ) as T, path );
        }
        public static IResourceRef RequestContent ( string path )
        {
            return RequestResource<Resource>( path );
        }


		public static List<ResourceRef<Resource>> GetAllDefaultResources()
		{
			return defaultContent.Select( r => new ResourceRef<Resource>( r ) ).ToList();
		}

        public static List<ResourceRef<T>> GetAvailContent<T> () where T : Resource
        {
            return resLibrary.Values.OfType<T>().Select( r => new ResourceRef<T>( r ) ).ToList();// Values.OfType<T>().Where( r => !r.Disposed ).Select( r => new ContentRef<T>( r ) ).ToList();
        }
        public static List<IResourceRef> GetAvailContent ( Type t )
        {
            return resLibrary.Values.Where( r => t.IsInstanceOfType( r ) /*&& !r.Disposed*/ ).Select( r => r.GetContentRef() ).ToList();
        }

        private static Resource LoadContent ( string path )
        {
            // Load the Resource and register it
            Resource res = null;/* Resource.Load<Resource>(path, r => {
                // Registering takes place in the callback - before initializing the Resource, because
                // that may result in requesting more Resources and an infinite loop if two Resources request
                // each other in their initialization code.
                if (r != null) RegisterResource(path, r);
            });*/
            return res;
        }

	}


}
