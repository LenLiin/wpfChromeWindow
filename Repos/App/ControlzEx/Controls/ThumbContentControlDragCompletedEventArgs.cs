using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace ControlzEx.Controls
{
    public class ThumbContentControlDragCompletedEventArgs : DragCompletedEventArgs
    {
        public ThumbContentControlDragCompletedEventArgs(double horizontalOffset, double verticalOffset, bool canceled)
            : base(horizontalOffset, verticalOffset, canceled)
        {
            this.RoutedEvent = ThumbContentControl.DragCompletedEvent;
        }
    }
}
