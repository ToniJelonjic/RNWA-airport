<?php
  class AirportReachableController {
    public function index() {
      $airport_reachables = AirportReachable::getAllAirportReachables();
      require_once('views/airport_reachable/index.php');
    }

    public function show() {
      if (!isset($_GET['id']))
        return call('pages', 'error');

      $airport_reachable = AirportReachable::findById($_GET['id']);
      require_once('views/airport_reachable/show.php');
    }

	public function deleteAirportReachableById() {
      if (!isset($_GET['id']))
        return call('pages', 'error');

      $airport_reachable = AirportReachable::deleteAirportReachableById($_GET['id']);
      require_once('views/airport_reachable/delete.php');
    }

    public function getAddAirportReachableView() {
        require_once('views/airport_reachable/add.php');
    }

    public function addAirportReachable() {
        if (!isset($_GET['Hops']))
            return call('pages', 'error');
        
        $airport_reachable = AirportReachable::addAirportReachable($_GET['Hops']);
        require_once('views/airport_reachable/added.php');
    }

    public function getEditAirportReachableView() {
        require_once('views/airport_reachable/edit.php');
    }

    public function editAirportReachableById() {
        if (!isset($_GET['AirportId']) || !isset($_GET['Hops']))
            return call('pages', 'error');
        
        $airport_reachable = AirportReachable::editAirportReachableById($_GET['AirportId'],$_GET['Hops']);
        require_once('views/airport_reachable/edited.php');
    }
  }
?>