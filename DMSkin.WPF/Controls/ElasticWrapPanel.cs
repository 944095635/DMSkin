using System;
using System.Windows;
using System.Windows.Controls;

namespace DMSkin.WPF.Controls
{
    public class ElasticWrapPanel : Panel
    {
        /// <summary>
        /// Identifies the <see cref="DesiredColumnWidth" /> dependency property.
        /// </summary>
        internal static readonly DependencyProperty DesiredColumnWidthProperty =
            DependencyProperty.Register("DesiredColumnWidth", typeof (double), typeof (ElasticWrapPanel),
                new PropertyMetadata(230d, OnDesiredColumnWidthChanged));

        /// <summary>
        /// The panel's number of columns
        /// </summary>
        private int _columns;

        /// <summary>
        /// The desired column width
        /// </summary>
        public double DesiredColumnWidth
        {
            private get { return (double) GetValue(DesiredColumnWidthProperty); }
            set { SetValue(DesiredColumnWidthProperty, value); }
        }

        /// <summary>
        /// Calculate the available space for each column
        /// </summary>
        /// <param name="availableSize">availableSize</param>
        /// <returns>Computed overrided size</returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            if (availableSize.Height.Equals(0))
                availableSize.Height = MaxHeight;

            _columns = (int) (availableSize.Width/DesiredColumnWidth);

            foreach (UIElement child in Children)
                child.Measure(availableSize);

            return base.MeasureOverride(availableSize);
        }

        /// <summary>
        /// Calculate the size of each column to organize their location
        /// </summary>
        /// <param name="finalSize">finalSize</param>
        /// <returns>Computed arranged size</returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (_columns == 0) return base.ArrangeOverride(finalSize);
            var columnWidth = Math.Floor(finalSize.Width/_columns);
            var totalHeight = 0d;
            var top = 0d;
            var rowHeight = 0d;
            var overflow = 0d;
            var column = 0;
            var index = 0;
            var overflowAlreadyCount = false;

            foreach (UIElement child in Children)
            {
                // Compute the tile size and position
                child.Arrange(new Rect(columnWidth*column, top, columnWidth, child.DesiredSize.Height));
                column++;
                rowHeight = Children.Count >= _columns
                    ? Math.Max(rowHeight, child.DesiredSize.Height)
                    : Math.Min(rowHeight, child.DesiredSize.Height);
                index++;

                // Check if the current element is at the end of a row and add an height overflow to get enough space for the next elements of the second row
                if (column == _columns && Children.Count != index && (Children.Count - index + 1) <= _columns &&
                    !overflowAlreadyCount)
                {
                    overflow = rowHeight;
                    totalHeight += rowHeight;
                    overflowAlreadyCount = true;
                }
                else
                {
                    if (!overflowAlreadyCount)
                        totalHeight += rowHeight;
                }

                if (column != _columns) continue;
                column = 0;
                top += rowHeight;
                rowHeight = 0;
            }

            if (Children.Count >= _columns)
                totalHeight = totalHeight/_columns + overflow;

            Height = totalHeight;
            finalSize.Height = totalHeight;
            return base.ArrangeOverride(finalSize);
        }

        /// <summary>
        /// Inform when DesiredColumnWidthProperty has changed
        /// </summary>
        /// <param name="e">e</param>
        /// <param name="obj">obj</param>
        private static void OnDesiredColumnWidthChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var panel = (ElasticWrapPanel) obj;
            panel.InvalidateMeasure();
            panel.InvalidateArrange();
        }
    }
}