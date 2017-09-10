using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringImageMaker.StringDrawing;

namespace StringImageMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            FontManager fontManager = new FontManager(
                    new string[] { "meiryo UI"},
                    minSize: 14,
                    maxSize: 14
                );
            IMessageCreator messageCreator =  RandomCharactorCreator.makeNumericCreator(minLen_: 3, maxLen_: 7);

            var drawer = new StringDrawer(messageCreator, fontManager);

            /*
            CharacterRange[] ranges = new CharacterRange[]{new CharacterRange(0, targetString.Length)};

            format.SetMeasurableCharacterRanges(ranges);

            Region[] regions = g.MeasureCharacterRanges(targetString, font, new RectangleF(x: 0, y: 0, width:256, height:128), format);
            
            foreach (var r in regions)
            {
                g.DrawRectangle(Pens.Blue, Rectangle.Round(r.GetBounds(g)));
            }
            */
            for (int i = 0; i < 10; i++)
            {
                var bitmap = drawer.drawNext();
                bitmap.Save(String.Format("sample{0}.png", i));
            }
        }
    }
}
