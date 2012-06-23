﻿/*
 * Copyright 2010 www.wojilu.com
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace wojilu.Net.Video {

    /// <summary>
    /// 优酷网视频抓取器
    /// </summary>
    public class YoukuSpider : IVideoSpider {

        private static readonly ILog logger = LogManager.GetLogger( typeof( YoukuSpider ) );

        public VideoInfo GetInfo( String url ) {

            String vid = strUtil.TrimStart( url, "http://v.youku.com/v_show/id_" );
            vid = strUtil.TrimEnd( vid, ".html" );

            String flashUrl = string.Format( "http://player.youku.com/player.php/sid/{0}/v.swf", vid );

            VideoInfo vi = new VideoInfo();
            vi.PlayUrl = url;
            vi.FlashUrl = flashUrl;
            vi.FlashId = vid;

            try {
                String pageBody = PageLoader.Download( url );

                Match mt = Regex.Match( pageBody, "<title>([^<]+?)</title>" );
                String title = VideoHelper.GetTitle( mt.Groups[1].Value );

                Match m = Regex.Match( pageBody, "pic=(http://[^:]+?.ykimg.com.+?)\"" );

                String picUrl = m.Groups[1].Value;

                vi.Title = title;
                vi.PicUrl = picUrl;

                return vi;

            }
            catch (Exception ex) {
                logger.Error( "getUrl=" + url );
                logger.Error( ex.Message );
                return vi;
            }

        }
    }

}
