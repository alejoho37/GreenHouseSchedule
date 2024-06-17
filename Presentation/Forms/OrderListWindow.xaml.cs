﻿using Domain.Processors;
using SupportLayer.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Presentation.Forms;

/// <summary>
/// Interaction logic for OrderListWindow.xaml
/// </summary>
public partial class OrderListWindow : Window
{
    //LATER - Add HeadersVisibility = "Column" to the datagrids across the board
    //LATER - Find out how to delete and order. Now I couldn't because the relation between order and orderlocations
    //is severed so i have to delete the orderlocations first in order to delete the actual order. I think I could set
    //"delete on cascade".
    private OrderProcessor _processor;
    private Orders _orders;
    private CollectionViewSource _viewSource;

    public OrderListWindow()
    {
        InitializeComponent();
        _processor = new OrderProcessor();
        _orders = (Orders)this.Resources["orders"];
        _viewSource = (CollectionViewSource)this.Resources["cvsOrders"];
        LoadData();
    }

    private void LoadData()
    {
        var orders = _processor.GetAllOrders();

        foreach (var order in orders)
        {
            _orders.Add(order);
        }
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        if (dgOrderList.SelectedItem is Order order)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar este registro?", "Eliminar registro"
                , MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _processor.DeleteOrder(order.Id);
                _orders.Remove(order);
            }
        }
        else
        {
            MessageBox.Show("Debe seleccionar el registro que desea eliminar."
                , "", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private void btnRowDetail_Click(object sender, RoutedEventArgs e)
    {
        var row = DataGridRow.GetRowContainingElement((Button)sender);

        row.DetailsVisibility = row.DetailsVisibility == Visibility.Visible ?
        Visibility.Collapsed : Visibility.Visible;
    }

    private void lbltxtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        //LATER - Change the implementation of all SearchTextBoxes.
        //Every time the text change a call to the database is made that is not performant
        //I'd rather to retrieve all records from the db and  then filter in the processor.
    private void CollectionViewSource_Filter(object sender, System.Windows.Data.FilterEventArgs e)
    {
        string filter = lbltxtSearch.TextBox.Text;
        _orders = new ObservableCollection<Order>(_processor.GetFilteredOrders(filter));
        dgOrderList.ItemsSource = null;
        dgOrderList.ItemsSource = _orders;
    }
}

//LATER - Give to this class a better name. And extract it in a separated file
public class DataContextHolderClass
{
    private ObservableCollection<Order> _orders;

    public ObservableCollection<Order> Orders { get; set; }
}
