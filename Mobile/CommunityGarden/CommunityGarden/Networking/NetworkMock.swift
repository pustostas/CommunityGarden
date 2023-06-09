//
//  NetworkMock.swift
//  CommunityGarden
//
//  Created by Ihor Golia on 03.06.2023.
//

import Foundation

class NetworkMock: NetworkLayerProtocol {
    
     func decodeNamed<T: Codable>(_ name: String)  -> T? {
         guard let url = Bundle.main.url(forResource: name, withExtension: "json") else {
            return nil
        }
         do {
             let data = try Data(contentsOf: url)
             return try JSONDecoder().decode(T.self, from: data)
         } catch {
             print("err \(error)")
             return nil
         }
         
    }
    
    
    func getMyUserData() async -> User? {
        decodeNamed("getMyUserData")
    }
    
    func getMyPlants() async -> Plants? {
        decodeNamed("getMyPlants")
    }
    
    func getMyGardens() async -> Gardens? {
        decodeNamed("getMyGardens")
    }
    
}
