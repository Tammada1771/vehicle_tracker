﻿using ART.VehicleTracker.BL;
using ART.VehicleTracker.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ART.VehicleTracker.UI
{
    public enum ScreenMode
    {
        Make = 1,
        Model = 2,
    }
    /// <summary>
    /// Interaction logic for MaintainAttributes.xaml
    /// </summary>
    public partial class MaintainAttributes : Window
    {
        List<Model> models;
        List<Make> makes;
        ScreenMode screenMode;

        public MaintainAttributes(ScreenMode screenmode)
        {
            InitializeComponent();
            screenMode = screenmode;

            Reload();

            cboAttribute.DisplayMemberPath = "Description";
            cboAttribute.SelectedValuePath = "Id";
            lblAttribute.Content = screenMode.ToString() + "s:";
            this.Title = "Maintain " + screenMode.ToString() + "s";
        }

        private async void Reload()
        {
            cboAttribute.ItemsSource = null;

            switch(screenMode)
            {
                case ScreenMode.Make:
                    makes = (List<Make>)await MakeManager.Load();
                    cboAttribute.ItemsSource = makes;
                    break;
                case ScreenMode.Model:
                    models = (List<Model>)await ModelManager.Load();
                    cboAttribute.ItemsSource = models;
                    break;
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            switch (screenMode)
            {

                /*
                case ScreenMode.Make:
                    Task.Run(async () =>
                    {
                        Make make = makes[cboAttribute.SelectedIndex];
                        make.Description = txtDescription.Text;
                        await MakeManager.Update(make);
                    });
                    break;
                case ScreenMode.Model:
                    Task.Run(async () =>
                    {
                        Model model = models[cboAttribute.SelectedIndex];
                        model.Description = txtDescription.Text;
                        await ModelManager.Update(model);
                    });
                    break;
                */
                case ScreenMode.Make:
                        Make make = makes[cboAttribute.SelectedIndex];
                        make.Description = txtDescription.Text;
                        MakeManager.SyncUpdate(make);
                    break;
                case ScreenMode.Model:
                        Model model = models[cboAttribute.SelectedIndex];
                        model.Description = txtDescription.Text;
                        ModelManager.SyncUpdate(model);
                    break;
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int results = 0;
            /*
            switch (screenMode)
            {
                case ScreenMode.Make:
                    Task.Run(async () =>
                    {
                        Guid id = makes[cboAttribute.SelectedIndex].Id;
                        results = await MakeManager.Delete(id);
                    });
                    break;
                case ScreenMode.Model:
                    Task.Run(async () =>
                    {
                        Guid id = models[cboAttribute.SelectedIndex].Id;
                        results = await ModelManager.Delete(id);
                    });
                    break;
            }
            */

            switch (screenMode)
            {
                case ScreenMode.Make:
                        Guid id = makes[cboAttribute.SelectedIndex].Id;
                        results = MakeManager.SyncDelete(id);
                    break;
                case ScreenMode.Model:
                        Guid id2 = models[cboAttribute.SelectedIndex].Id;
                        results = ModelManager.SyncDelete(id2);
                    break;
            }
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            /*
            switch (screenMode)
            {
                case ScreenMode.Make:
                    Task.Run(async () =>
                    {
                        int results = await MakeManager.Insert(new Make { Description = txtDescription.Text });
                    });
                    break;
                case ScreenMode.Model:
                    Task.Run(async () =>
                    {
                        int results = await ModelManager.Insert(new Model { Description = txtDescription.Text });
                    });
                    break;

            }
            */

            switch (screenMode)
            {
                case ScreenMode.Make:
                        int results = MakeManager.SyncInsert(new Make { Description = txtDescription.Text });
                    break;
                case ScreenMode.Model:
                    Task.Run(async () =>
                    {
                        int results = ModelManager.SyncInsert(new Model { Description = txtDescription.Text });
                    });
                    break;

            }
        }

        private void CboAttribute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboAttribute.SelectedIndex > -1)
            {
                if (screenMode == ScreenMode.Make)
                    txtDescription.Text = makes[cboAttribute.SelectedIndex].Description;
                else
                    txtDescription.Text = models[cboAttribute.SelectedIndex].Description;
            }
        }

    }
}
