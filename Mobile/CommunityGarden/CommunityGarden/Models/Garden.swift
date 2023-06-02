//
//  Garden.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 02.06.2023.
//

import Foundation
import CoreGraphics

struct Garden: Codable, Hashable, Identifiable {
    
    var id: String
    var name: String
    var ownerId: String
    var code: String
    var size: CGSize
    var plots: Array<Plot>
}
