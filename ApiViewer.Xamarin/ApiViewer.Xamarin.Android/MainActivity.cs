////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	MainActivity.cs
//
// summary:	Implements the main activity class
////////////////////////////////////////////////////////////////////////////////////////////////////

using Android.App;
using Android.Content.PM;
using Android.OS;

namespace ApiViewer.Xamarin.Droid
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A main activity. </summary>
    ///
    /// <remarks>   James Coates, 8/26/2017. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [Activity(Label = "ApiViewer.Xamarin.Android", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Called when the activity is starting. </summary>
        ///
        /// <remarks>
        ///        <para tool="javadoc-to-mdoc">Called when the activity is starting.  This is where most
        ///        initialization
        ///     should go: calling
        ///     <c><see cref="M:Android.App.Activity.SetContentView(System.Int32)" /></c> to inflate the
        ///     activity's UI, using
        ///     <c><see cref="M:Android.App.Activity.FindViewById(System.Int32)" /></c> to
        ///     programmatically interact with widgets in the UI, calling
        ///     <c><see cref="M:Android.App.Activity.ManagedQuery(Android.Net.Uri, System.String[], System.String[], System.String[], System.String[])" /></c>
        ///     to retrieve
        ///     cursors for data being displayed, etc.
        ///     
        ///     </para>
        ///        <para tool="javadoc-to-mdoc">You can call
        ///        <c><see cref="M:Android.App.Activity.Finish" /></c> from within this function, in
        ///     which case onDestroy() will be immediately called without any of the rest of the activity
        ///     lifecycle (<c><see cref="M:Android.App.Activity.OnStart" /></c>,
        ///     <c><see cref="M:Android.App.Activity.OnResume" /></c>,
        ///     <c><see cref="M:Android.App.Activity.OnPause" /></c>, etc) executing.
        ///     
        ///     </para>
        ///        <para tool="javadoc-to-mdoc">
        ///          <i>Derived classes must call through to the super class's
        ///     implementation of this method.  If they do not, an exception will be thrown.</i>
        ///        </para>
        ///        <para tool="javadoc-to-mdoc">
        ///          <format type="text/html">
        ///     <a href="http://developer.android.com/reference/android/app/Activity.html#onCreate(android.os.Bundle)" target="_blank">[Android
        ///     Documentation]</a>
        ///          </format>
        ///        </para>
        /// </remarks>
        ///
        /// <param name="bundle">   The bundle. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}