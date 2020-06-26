using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace ControlzEx.Controls
{
    public class ThumbContentControlDragStartedEventArgs : DragStartedEventArgs
    {
        public ThumbContentControlDragStartedEventArgs(double horizontalOffset, double verticalOffset)
            : base(horizontalOffset, verticalOffset)
        {
            this.RoutedEvent = ThumbContentControl.DragStartedEvent;
        }
    }
}
