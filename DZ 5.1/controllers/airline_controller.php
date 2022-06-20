<?php
  class AirlineController {
    public function index() {
      $Airlines = Airline::getAllAirlines();
      $data['airlines'] = $Airlines;
      require_once('views/airline/index.php');
    }


	public function deleta() {
      if (!isset($_GET['id']))
        return call('pages', 'error');

      $Airline = Airline::deleteAirlineById($_GET['id']);
      $data['airline'] = $Airline;

      require_once('views/airline/delete.php');
    }

    public function getAddAirlineView() {
        require_once('views/airline/add.php');
    }
 
    public function add() {
      if (isset($_POST['iata'], $_POST['airlinename']) && isset($_POST['base_airport'])) {
        $Airline = Airline::addAirline($_GET['Iata'], $_GET['Airlinename'], $_GET['Base_Airport']);
        $data['airline'] = $Airline;
      }
      require_once('views/airline/add.php');
    }

    public function getEditAirlineView() {
        require_once('views/airline/edit.php');
    }

    public function editAirlineById() {
        if (!isset($_GET['Iata']) || !isset($_GET['Airlinename']) || !isset($_GET['Base_Airport']))
            return call('pages', 'error');
        
        $Airline = Airline::editAirlineById($_GET['AirlineId'], $_GET['Iata'], $_GET['Airlinename'], $_GET['Base_Airport']);
        $data['airline'] = $Airline;

        require_once('views/airline/edited.php');
    }
  }
