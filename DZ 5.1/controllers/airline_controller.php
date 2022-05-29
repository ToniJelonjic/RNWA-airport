<?php
  class AirlineController {
    public function index() {
      $Airlines = Airline::getAllAirlines();
      require_once('views/airline/index.php');
    }

    public function show() {
      if (!isset($_GET['id']))
        return call('pages', 'error');

      $Airline = Airline::findById($_GET['id']);
      require_once('views/airline/show.php');
    }

	public function deleteAirlineById() {
      if (!isset($_GET['id']))
        return call('pages', 'error');

      $Airline = Airline::deleteAirlineById($_GET['id']);
      require_once('views/airline/delete.php');
    }

    public function getAddAirlineView() {
        require_once('views/airline/add.php');
    }

    public function addAirline() {
        if (!isset($_GET['Iata'], $_GET['Airlinename']) || !isset($_GET['Base_Airport']))
            return call('pages', 'error');
        
        $Airline = Airline::addAirline($_GET['Iata'], $_GET['Airlinename'], $_GET['Base_Airport']);
        require_once('views/airline/added.php');
    }

    public function getEditAirlineView() {
        require_once('views/airline/edit.php');
    }

    public function editAirlineById() {
        if (!isset($_GET['Iata']) || !isset($_GET['Airlinename']) || !isset($_GET['Base_Airport']))
            return call('pages', 'error');
        
        $Airline = Airline::editAirlineById($_GET['AirlineId'], $_GET['Iata'], $_GET['Airlinename'], $_GET['Base_Airport']);
        require_once('views/airline/edited.php');
    }
  }
?>