//
//  Plant.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 02.06.2023.
//

import Foundation

struct Plant: Codable, Hashable, Identifiable{
    var id: String
    var name = "Rhododendron"
    var imageURL = "https://media.istockphoto.com/id/1372896722/photo/potted-banana-plant-isolated-on-white-background.jpg?s=612x612&w=0&k=20&c=bioeNAo7zEqALK6jvyGlxeP_Y7h6j0QjuWbwY4E_eP8="
    var description = "Rhododendron is a genus of shrubs and small to (rarely) large trees, the smallest species growing to 10–100 cm (4–40 in) tall, and the largest, R. protistum var. giganteum, reported to 30 m (100 ft) tall.[9][10] The leaves are spirally arranged; leaf size can range from 1–2 cm (0.4–0.8 in) to over 50 cm (20 in), exceptionally 100 cm (40 in) in R. sinogrande. They may be either evergreen or deciduous. In some species, the undersides of the leaves are covered with scales (lepidote) or hairs (indumentum)."
    var type = "Ericaceae"
    var plantDate = "somedate"
    var waterEvery = 14
    var wikiUrl = "https://en.wikipedia.org/wiki/Rhododendron"
}
