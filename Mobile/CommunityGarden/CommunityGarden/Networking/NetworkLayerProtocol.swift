//
//  NetworkLayerProtocol.swift
//  CommunityGarden
//
//  Created by Ihor Golia on 03.06.2023.
//

import Foundation

protocol NetworkLayerProtocol {
    
   // func login(email: String, password: String) async -> User?
    func getMyUserData() async -> User?
    func getMyPlants() async -> Plants?
    func getMyGardens() async -> Gardens?
}
