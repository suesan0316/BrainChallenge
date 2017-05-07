using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace BrainChallenge.Droid
{
    internal class Util
    {
        public  static T GenerateView<T>(Context context, string styleName) where T : View
        {
            var styleId = (int)typeof(Resource.Style).GetField(styleName).GetValue(null);

            var viewType = typeof(T);
            var args = new object[] { context, null, styleId, styleId };
            //var args = new object[] { new ContextThemeWrapper(context, styleId) };
            var view = (T)Activator.CreateInstance(viewType, args);

            var xml = XDocument.Load(context.Assets.Open("Styles.xml"));

            var styles = xml.Descendants("style");

            var result = from n in styles where n.Attribute("name").Value.Equals(styleName) select n;

            var items = result.Descendants("item");

            var result2 = from n in items select n;

            var list = result2.ToList();

            var layout_height = -1;
            var layout_width = -1;
            var layout_marginBottom = 0;
            var layout_marginLeft = 0;
            var layout_marginRight = 0;
            var layout_marginTop = 0;
            var paddingLeft = 0;
            var paddingTop = 0;
            var paddingBottom = 0;
            var paddingRight = 0;

            foreach (var val in list)
            {
                var name = val.Attribute("name").Value;

                if (name.Equals("android:layout_height"))
                {
                    if (!int.TryParse(val.Value, out layout_height))
                    {
                        if (val.Value.Equals("wrap_content"))
                        {
                            layout_height = -2;
                        }
                        else
                        {
                            layout_height = -1;
                        }
                    }
                }else if (name.Equals("android:layout_width"))
                {
                    if (!int.TryParse(val.Value, out layout_width))
                    {
                        if (val.Value.Equals("wrap_content"))
                        {
                            layout_width = -2;
                        }
                        else
                        {
                            layout_width = -1;
                        }

                      }
                }else if (name.Equals("android:layout_marginBottom"))
                {
                    int.TryParse(val.Value, out layout_marginBottom);
                }
                else if (name.Equals("android:layout_marginLeft"))
                {
                    int.TryParse(val.Value, out layout_marginLeft);
                }
                else if (name.Equals("android:layout_marginRight"))
                {
                    int.TryParse(val.Value, out layout_marginRight);
                }
                else if (name.Equals("android:layout_marginTop"))
                {
                    int.TryParse(val.Value, out layout_marginTop);
                }
                else if (name.Equals("android:paddingLeft"))
                {
                    int.TryParse(val.Value, out paddingLeft);
                }
                else if (name.Equals("android:paddingTop"))
                {
                    int.TryParse(val.Value, out paddingTop);
                }
                else if (name.Equals("android:paddingBottom"))
                {
                    int.TryParse(val.Value, out paddingBottom);
                }
                else if (name.Equals("android:paddingRight"))
                {
                    int.TryParse(val.Value, out paddingRight);
                }
            }

            var layoutParams = new LinearLayout.LayoutParams(layout_width, layout_height);
            
            view.SetPadding(paddingLeft, paddingTop, paddingRight, paddingBottom);
            layoutParams.SetMargins(layout_marginLeft, layout_marginTop, layout_marginRight, layout_marginBottom);
            
            view.LayoutParameters = layoutParams;
            return view;
        }
    }
}