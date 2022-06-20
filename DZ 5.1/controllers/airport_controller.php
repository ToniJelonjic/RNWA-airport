<?php
  class AirportController {
    public function index() {
      $Airports = Airport::getAllAirports();
      $data['airports'] = $Airports;

      require_once('views/airport/index.php');
    }

    public function show() {
      if (!isset($_GET['id']))
        return call('pages', 'error');

      $Airport = Airport::findById($_GET['id']);
      require_once('views/airport/show.php');
    }

	public function deleteAirportById() {
      if (!isset($_GET['id']))
        return call('pages', 'error');

      $Airport = Airport::deleteAirportById($_GET['id']);
      require_once('views/airport/delete.php');
    }

    public function getAddAirportView() {
        require_once('views/airport/add.php');
    }

    public function addAirport() {
        if (!isset($_GET['Name']) || !isset($_GET['Iata']) || !isset($_GET['Icao']))
            return call('pages', 'error');
        
        $Airport = Airport::addAirport($_GET['Name'], $_GET['Iata'], $_GET['Icao']);
        require_once('views/airport/added.php');
    }

    public function getEditAirportView() {
        require_once('views/airport/edit.php');
    }

    public function editAirportById() {
        if (!isset($_GET['AirportID']) || !isset($_GET['Name']) || !isset($_GET['Iata']) || !isset($_GET['Icao']))
            return call('pages', 'error');
        
        $Airport = Airport::editAirportById($_GET['AirportID'], $_GET['Name'], $_GET['Iata'], $_GET['Icao']);
        require_once('views/airport/edited.php');
    }
  }
?>