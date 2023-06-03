//
//  NetworkLayerProtocol.swift
//  CommunityGarden
//
//  Created by Ihor Golia on 03.06.2023.
//

import Foundation

protocol NetworkLayerProtocol {
    func getMyGarden() async -> Garden?
    func getMyUserData() async -> User?
}
