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

namespace wojilu.Common.Resource {

    /// <summary>
    /// 属性数据项，常用于下拉列表中
    /// </summary>
    public class PropertyItem {

        private String _name;
        private int _value;

        public PropertyItem() {
        }

        public PropertyItem( String name, int val ) {
            _name = name;
            _value = val;
        }

        public String Name {
            get { return _name; }
            set { _name = value; }
        }

        public int Value {
            get { return _value; }
            set { _value = value; }
        }

    }
}

