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
using wojilu.Drawing;

namespace wojilu.Web.Utils {

    public class AvatarUploadSaver : AvatarSaver {

        public HttpFile postedFile { get; set; }

        public AvatarUploadSaver( HttpFile _postedFile ) {
            postedFile = _postedFile;
        }

        public override string GetExt() {
            return Img.GetImageExt( postedFile.ContentType );
        }

        public override void Save( string absPath ) {
            postedFile.SaveAs( absPath );
        }
    }

}
