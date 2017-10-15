using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DM_Studio.Control
{
    /// <summary>
    /// 水印输入框
    /// </summary>
    public class WaterMaskTextBox : TextBox
    {
        /// <summary>
        /// 水印文本
        /// </summary>
        public string HintText
        {
            get { return (string)GetValue(HintTextProperty); }
            set { SetValue(HintTextProperty, value); }
        }
        /// <summary>
        /// 水印文本依赖属性
        /// </summary>
        public static readonly DependencyProperty HintTextProperty =
            DependencyProperty.Register("HintText",
                typeof(string),
                typeof(WaterMaskTextBox),
                new PropertyMetadata(string.Empty,
                    (DependencyObject d, DependencyPropertyChangedEventArgs e) =>
                    {
                        var oldValue = Convert.ToString(e.OldValue);
                        var newValue = Convert.ToString(e.NewValue);
                        var sender = d as WaterMaskTextBox;
                        if (sender != null)
                        {
                            if (string.IsNullOrWhiteSpace(oldValue))
                            {
                                if (string.IsNullOrWhiteSpace(newValue))
                                {
                                    sender.GotFocus -= Sender_GotFocus;
                                    sender.LostFocus += Sender_LostFocus;
                                }
                                else
                                {
                                    sender.GotFocus += Sender_GotFocus;
                                    sender.LostFocus += Sender_LostFocus;
                                    sender.Text = sender.HintText;
                                }
                            }
                        }
                    }));






        /// <summary>
        /// 密码提示符号
        /// </summary>
        public Char PasswordHintChar
        {
            get { return (Char)GetValue(PasswordHintCharProperty); }
            set { SetValue(PasswordHintCharProperty, value); }
        }

        /// <summary>
        /// 密码提示符号依赖属性
        /// </summary>
        public static readonly DependencyProperty PasswordHintCharProperty =
            DependencyProperty.Register("PasswordHintChar", typeof(Char), typeof(WaterMaskTextBox), new PropertyMetadata('*'));


        /// <summary>
        /// true标识为密码框，false标识为文本框
        /// </summary>
        public bool IsPasswordBox
        {
            get { return (bool)GetValue(IsPasswordBoxProperty); }
            set { SetValue(IsPasswordBoxProperty, value); }
        }

        /// <summary>
        /// true标识为密码框，false标识为文本框依赖属性
        /// </summary>
        public static readonly DependencyProperty IsPasswordBoxProperty =
            DependencyProperty.Register("IsPasswordBox",
                typeof(bool),
                typeof(WaterMaskTextBox),
                new PropertyMetadata(false, (DependencyObject d, DependencyPropertyChangedEventArgs e) =>
                {
                    var oldValue = (bool)e.OldValue;
                    var newValue = (bool)e.NewValue;
                    var sender = d as WaterMaskTextBox;
                    if (sender != null)
                    {
                        if (oldValue != newValue)
                        {
                            if (newValue)
                            {
                                sender.TextChanged += Password_TextChanged;
                                InputMethod.SetIsInputMethodEnabled(sender, false);
                            }
                            else
                            {
                                sender.TextChanged -= Password_TextChanged;
                                InputMethod.SetIsInputMethodEnabled(sender, true);
                                sender.Text = sender.Password;
                            }
                        }
                    }
                }));


        /// <summary>
        /// 是否有 水印提示文本
        /// </summary>
        public bool HasHintText
        {
            get { return (bool)GetValue(HasHintTextProperty); }
            set { SetValue(HasHintTextProperty, value); }
        }

        public Brush HintForeground
        {
            get { return (Brush)GetValue(HintForegroundProperty); }
            set { SetValue(HintForegroundProperty, value); }
        }
        public static readonly DependencyProperty HintForegroundProperty =
        DependencyProperty.Register("HintForegroundProperty", typeof(Brush), typeof(WaterMaskTextBox), new PropertyMetadata());

        public Brush TextForeground
        {
            get { return (Brush)GetValue(TextForegroundProperty); }
            set { SetValue(TextForegroundProperty, value); }
        }
        public static readonly DependencyProperty TextForegroundProperty =
        DependencyProperty.Register("TextForegroundProperty", typeof(Brush), typeof(WaterMaskTextBox), new PropertyMetadata());
        

        /// <summary>
        /// 是否有 水印提示文本 依赖属性
        /// </summary>
        public static readonly DependencyProperty HasHintTextProperty =
            DependencyProperty.Register("HasHintText", typeof(bool), typeof(WaterMaskTextBox), new PropertyMetadata(false));

        /// <summary>
        /// 获取输入的密码
        /// </summary>
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            private set { SetValue(PasswordProperty, value); }
        }
        /// <summary>
        /// 获取输入的密码
        /// </summary>
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(WaterMaskTextBox), new PropertyMetadata(string.Empty));


        /// <summary>
        /// 输入密码文本改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var textBox = sender as WaterMaskTextBox;
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    if (textBox.Text == textBox.HintText)
                    {
                        return;
                    }
                    Action<WaterMaskTextBox, int, int> setNewValue = (tb, newC, newS) =>
                    {
                        var newText = string.Empty;
                        for (int i = 0; i < newC; i++)
                        {
                            newText += textBox.PasswordHintChar;
                        }
                        tb.Text = newText;
                        tb.SelectionStart = newS;
                    };

                    var lastInput = textBox.Password;
                    var selectionStart = textBox.SelectionStart;
                    var newChars = textBox.Text.ToList();
                    var newChar = newChars.Find(i => i != textBox.PasswordHintChar);
                    if (newChar != 0)//新输入字符
                    {
                        var newCharIndex = newChars.IndexOf(newChar);
                        if (newCharIndex > 0)
                        {
                            textBox.Password = lastInput.Insert(newCharIndex, newChar.ToString());
                        }
                        else
                        {
                            textBox.Password = newChar.ToString();
                        }
                        setNewValue(textBox, newChars.Count, selectionStart);
                    }
                    else//没有新输入字符串或新输入字符和密码字符一样
                    {
                        if (lastInput.Length < newChars.Count)//输入了新字符且和密码字符一样
                        {
                            textBox.Password = lastInput.Insert(textBox.SelectionStart - 1, textBox.PasswordHintChar.ToString());
                            setNewValue(textBox, newChars.Count, selectionStart);
                        }
                        else if (lastInput.Length > newChars.Count)//没有输入字符且删除了一个字符
                        {
                            if (lastInput.Length == textBox.SelectionStart)//删除了最后一个字节
                            {
                                textBox.Password = lastInput.Remove(lastInput.Length - 1, 1);
                            }
                            else//删除了非最后一个字节
                            {
                                textBox.Password = lastInput.Remove(textBox.SelectionStart, 1);
                            }
                            setNewValue(textBox, newChars.Count, selectionStart);
                        }
                    }
                }
                else
                {
                    textBox.Password = string.Empty;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Test"+ex.Message);
            }
          
        }

        /// <summary>
        /// 当获得焦点是
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Sender_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as WaterMaskTextBox;
            if (textBox.Text == textBox.HintText)
            {
                textBox.Text = string.Empty;
            }
            textBox.Foreground = textBox.TextForeground;
        }
        /// <summary>
        /// 当失去焦点时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Sender_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as WaterMaskTextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.HintText;
                textBox.Foreground = textBox.HintForeground;
            }
        }

    }
}
