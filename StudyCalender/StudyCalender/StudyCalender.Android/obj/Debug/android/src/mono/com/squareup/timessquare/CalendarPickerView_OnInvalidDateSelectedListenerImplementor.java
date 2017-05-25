package mono.com.squareup.timessquare;


public class CalendarPickerView_OnInvalidDateSelectedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.squareup.timessquare.CalendarPickerView.OnInvalidDateSelectedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInvalidDateSelected:(Ljava/util/Date;)V:GetOnInvalidDateSelected_Ljava_util_Date_Handler:SquareUp.TimesSquare.CalendarPickerView/IOnInvalidDateSelectedListenerInvoker, AndroidTimesSquare\n" +
			"";
		mono.android.Runtime.register ("SquareUp.TimesSquare.CalendarPickerView+IOnInvalidDateSelectedListenerImplementor, AndroidTimesSquare, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CalendarPickerView_OnInvalidDateSelectedListenerImplementor.class, __md_methods);
	}


	public CalendarPickerView_OnInvalidDateSelectedListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CalendarPickerView_OnInvalidDateSelectedListenerImplementor.class)
			mono.android.TypeManager.Activate ("SquareUp.TimesSquare.CalendarPickerView+IOnInvalidDateSelectedListenerImplementor, AndroidTimesSquare, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onInvalidDateSelected (java.util.Date p0)
	{
		n_onInvalidDateSelected (p0);
	}

	private native void n_onInvalidDateSelected (java.util.Date p0);

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
