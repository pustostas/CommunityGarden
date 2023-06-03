//
//  Singleton.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 02.06.2023.
//

import Foundation
import Combine

class Singleton: ObservableObject {

    @Published var isLoged = true
    
    @Published var rootRoute = RootRoute.gardens

    
    
    
    func boolRoute(route: RootRoute) -> AnyPublisher<Bool, Never> {
        $rootRoute
            .map { newRootRoute in
                return newRootRoute == route
            }
            .eraseToAnyPublisher()

    }
    
    enum RootRoute {
        case gardens
        case gardenMap
        case myPlans
        case settings
        case chats
        case calendar
        
    }
    
    var me: User?
    
    var myGarden: Garden?
    
    var myPlants: Plants?
    
    var network: NetworkLayerProtocol
    
    static var shared: Singleton = {
        let instance = Singleton()
        return instance
    }()
    
    /// Инициализатор Одиночки всегда должен быть скрытым, чтобы предотвратить
    /// прямое создание объекта через инициализатор.
    private init() {
        network = NetworkMock()
        Task {
            await prepareUserGardenData()
            await prepareUserData()
            await preparePlantsData()
        }
    }

    
    /// Наконец, любой одиночка должен содержать некоторую бизнес-логику,
    /// которая может быть выполнена на его экземпляре.
    func someBusinessLogic() -> String {
        // ...
        return "Result of the 'someBusinessLogic' call"
    }
    
    func prepareUserGardenData() async {
        myGarden = await network.getMyGarden()
    }
    func prepareUserData() async {
        me = await network.getMyUserData()
    }
    func preparePlantsData() async {
        myPlants = await network.getMyPlants()
    }
}

/// Одиночки не должны быть клонируемыми.
extension Singleton: NSCopying {

    func copy(with zone: NSZone? = nil) -> Any {
        return self
    }
}
