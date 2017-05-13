using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerHost.Common
{
    public static class YouTubeValues
    {
        public static string YouTubeAddress = "http://www.youtube.com";
        internal static string Beginning="0";
        internal static string LockupTittle = "yt-lockup-title ";
        internal static string LockupContent = "yt-lockup-content";
        internal static string SearchBox= "masthead-search-term";
        internal static string AccessibleDescription = "accessible-description";
        internal static string VideoField= "movie_player";
        internal static string VideoLinkXPath = "//a[@title=\"{0}\"]";
        internal static string VideoLinkXPathSignleQuotes= "//a[@title='{0}']";
        internal static string WatchFieldTitle= "watch-title";
        internal static string DurationString = " - Duration:";
        internal static string VideoTime = "video-time";
        internal static string YTMainVideoLockup = "yt-lockup-dismissable";
        internal static string RelatedVideoContainer = "video-list-item related-list-item related-list-item-compact-video";
        internal static string NextVideoContainer = "video-list-item related-list-item";
        internal static string LiContainsVideo= "//li[contains(@class,'video')]";
        internal static string CommercialSkipPartial = "//div[contains(@class,'videoAdUiSkipContainer')]";
    }
}
