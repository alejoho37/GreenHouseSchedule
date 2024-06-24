﻿using log4net;
using Presentation.IRequesters;
using SupportLayer;
using System;
using System.Windows;

namespace Presentation.InputForms;

/// <summary>
/// Interaction logic for DeliverInputWindow.xaml
/// </summary>
public partial class DeliverInputWindow : Window
{
    private static readonly ILog _log = LogHelper.GetLogger();
    private IDeliveredBlockRequester _requester;
    public DeliverInputWindow(IDeliveredBlockRequester requestingWindow)
    {
        InitializeComponent();
        _requester = requestingWindow;
        dtpDeliveryDate.TimePicker.SelectedDate = DateTime.Today;

        log4net.GlobalContext.Properties["Model"] = _requester.BlockInProcess;
        _log.Info("The DeliverInputWindow was opened to deliver a Block");
        log4net.GlobalContext.Properties["Model"] = "";
    }

    private void btnConfirm_Click(object sender, RoutedEventArgs e)
    {
        if (ValidateData() == true)
        {
            try
            {
                _requester.SetTheDeliveredBlock(dtpDeliveryDate.SelectedDateOnly, lbltxtDeliveredAmount.ShortNumber);
                this.Close();
            }
            catch (ArgumentException ex)
            {
                int endIndex = ex.Message.IndexOf('(');

                endIndex--;

                log4net.GlobalContext.Properties["Model"] = _requester.BlockInProcess;
                _log.Warn("It was passed an incorrect argument", ex);
                log4net.GlobalContext.Properties["Model"] = "";

                MessageBox.Show($"{ex.Message.Substring(0, endIndex)}.");

                if (ex.ParamName == "date")
                {
                    this.dtpDeliveryDate.TimePicker.Focus();
                }
                else if (ex.ParamName == "deliveredSeedTrays")
                {
                    this.lbltxtDeliveredAmount.TextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                log4net.GlobalContext.Properties["Model"] = _requester.BlockInProcess;
                _log.Error("There was an error delivering a block", ex);
                log4net.GlobalContext.Properties["Model"] = "";

                MessageBox.Show($"{ex.Message}");
            }
        }
    }

    private bool ValidateData()
    {
        if (dtpDeliveryDate.TimePicker.SelectedDate == null)
        {
            MessageBox.Show("Debe especificar la fecha en la que se sembraron estas bandejas"
                , "Dato faltante"
                , MessageBoxButton.OK, MessageBoxImage.Information);
            dtpDeliveryDate.TimePicker.Focus();
            return false;
        }

        if (lbltxtDeliveredAmount.FieldContent == null
            || lbltxtDeliveredAmount.FieldContent == "")
        {
            MessageBox.Show("Debe especificar la cantidad de bandejas sembradas.", "Dato faltante"
                , MessageBoxButton.OK, MessageBoxImage.Information);
            lbltxtDeliveredAmount.TextBox.Focus();
            return false;
        }
        else if (short.TryParse(lbltxtDeliveredAmount.FieldContent, out short amountOfSeedlings) == false)
        {
            MessageBox.Show("La cantidad de bandejas sembradas no esta en el formato correcto."
                , "Cantidad de bandejas sembradas inválida"
                , MessageBoxButton.OK, MessageBoxImage.Warning);
            lbltxtDeliveredAmount.TextBox.Focus();
            return false;
        }

        return true;
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}
