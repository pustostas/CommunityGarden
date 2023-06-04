//
//  Plant.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 02.06.2023.
//

import Foundation

struct Plant: Codable, Hashable, Identifiable{
    var id: String
    var name: String
    var imageURL: URL?
    var description: String
    var type: String
    var plantDate: String
    var waterEvery: Int
    var wikiUrl: URL?
}
