Public Interface IMiniHotelPMSService
    Function GetAvailableRaters(ByVal Body As AvailableRaterDTO) As MiniHotelPMSModel(Of AvailableRatersModel)
    Function GetReservations(ByVal Body As ReservationDTO) As MiniHotelPMSModel(Of ReservationsRSModel)
End Interface
