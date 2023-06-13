﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using StudentManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManagement.ViewModel;

public sealed partial class MainViewModel : ObservableObject
{

    public MainViewModel()
    {
        Init();
        Instance = this;
    }

    #region property

    private object _programViewModel;
    private object _studentViewModel;
    private object _teacherViewModel;
    private object _classListViewModel;
    private object _transcriptViewModel;
    private object _classconfigViewModel;
    private object _classDetailViewModel;
    private object _classManaViewModel;

    private object _subjectViewModel;
    private object _schoolyearViewModel;
    private object _classListDetailsViewModel;
    private object _termSummaryViewModel;
    [ObservableProperty]
    public ObservableCollection<Navigation> leftNavigations;
    private static MainViewModel s_instance;
    public static MainViewModel Instance
    {
        get => s_instance == null ? (s_instance = new MainViewModel()) : s_instance;
        private set => s_instance = value;
    }

    private object contentViewModel;
    public object ContentViewModel
    {
        get { return contentViewModel; }
        private set
        {
            contentViewModel = value;
            OnPropertyChanged();
        }
    }
    #endregion
    public void Init()
    {

        DataProvider.ins.context.Hocsinhs.ToList();
        _programViewModel = new ProgramViewModel();
        _studentViewModel = new StudentViewModel();
        _teacherViewModel = new TeacherViewModel();
        //_classListViewModel = new ClassListViewModel();
        _subjectViewModel = new SubjectViewModel();
        _schoolyearViewModel = new SchoolYearViewModel();
        _termSummaryViewModel = new TermSummaryViewModel();

        leftNavigations = new ObservableCollection<Navigation>()
    {
        new Navigation("Trang chủ", "home", _programViewModel),
        new Navigation("Thông tin", "infomation", _classListDetailsViewModel),
        new Navigation("Tổng kết", "subject", _termSummaryViewModel),

        //new Navigation("Môn học", "subject", new ClassListViewModel()),
        //new Navigation("Thông tin", "infomation", ),
        new Navigation("Lớp học", "subject", new ClassManagementViewModel()),
        new Navigation("Thêm năm học", "subject", _schoolyearViewModel),
    };
        leftNavigations[0].IsPress = true;
        ContentViewModel = _programViewModel;
    }
    public void Refresh()
    {
        foreach(var item in leftNavigations)
        {
            item.IsPress = false;
        }
        leftNavigations[0].IsPress = true;
        ContentViewModel = _programViewModel;
    }

    public void setViewModel(object viewModel)
    {
        ContentViewModel = viewModel;
    }

    [RelayCommand]
    private void CloseWindow()
    {
        Application.Current.Shutdown();
    }
    [RelayCommand]
    private void HideWindow()
    {
        Window window = Application.Current.MainWindow as Window;
        window.WindowState = WindowState.Minimized;
    }
    [RelayCommand]
    private void SignOut()
    {
        LoginWindow window = new LoginWindow();
        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
        
        Application.Current.MainWindow = window;
        window.Show();
        mainWindow.Close();
    }
}

