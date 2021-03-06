﻿using System;
using System.Collections.Generic;

namespace PCL.Presenter
{
    public class Presenter
    {
        private IRepository _repository;
        private List<FriendVM> _viewModel { get; set; }

        public Presenter(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public List<FriendVM> GetFriendVM()
        {
            _viewModel = new List<FriendVM>();

            var friends = _repository?.GetListOfFriends() ?? new List<Friend>();

            foreach (var item in friends)
            {
                _viewModel.Add(new FriendVM { FirstLastName = $"{item?.FirstName} {item?.LastName}" });
            }
            return _viewModel;
        }
    }
}
