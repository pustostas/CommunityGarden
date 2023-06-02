//
//  Plot.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 02.06.2023.
//

import Foundation
import CoreGraphics

struct Plot: Codable, Hashable, Identifiable {
    var id: String
    var superviserId: String
    var gardenId: String = ""
    var zeroPoint: CGPoint
    var size: CGSize
}
