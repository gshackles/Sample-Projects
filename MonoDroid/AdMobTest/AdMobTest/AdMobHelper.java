package samples.admobtest;

import android.view.View;
import com.admob.android.ads.AdManager;
import com.admob.android.ads.AdView;

public class AdMobHelper
{
	private AdMobHelper() { }
	
	public static void registerEmulatorAsTestDevice()
	{
		AdManager.setTestDevices(new String[] { AdManager.TEST_EMULATOR });
	}

	public static void requestFreshAd(View view)
	{
		((AdView)view).requestFreshAd();
	}
}