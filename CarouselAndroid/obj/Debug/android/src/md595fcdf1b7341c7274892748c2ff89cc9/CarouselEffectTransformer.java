package md595fcdf1b7341c7274892748c2ff89cc9;


public class CarouselEffectTransformer
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.view.ViewPager.PageTransformer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_transformPage:(Landroid/view/View;F)V:GetTransformPage_Landroid_view_View_FHandler:Android.Support.V4.View.ViewPager/IPageTransformerInvoker, Xamarin.Android.Support.Core.UI\n" +
			"";
		mono.android.Runtime.register ("Naxam.Controls.CarouselEffectTransformer, Naxam.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CarouselEffectTransformer.class, __md_methods);
	}


	public CarouselEffectTransformer () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CarouselEffectTransformer.class)
			mono.android.TypeManager.Activate ("Naxam.Controls.CarouselEffectTransformer, Naxam.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public CarouselEffectTransformer (android.content.Context p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == CarouselEffectTransformer.class)
			mono.android.TypeManager.Activate ("Naxam.Controls.CarouselEffectTransformer, Naxam.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public void transformPage (android.view.View p0, float p1)
	{
		n_transformPage (p0, p1);
	}

	private native void n_transformPage (android.view.View p0, float p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}